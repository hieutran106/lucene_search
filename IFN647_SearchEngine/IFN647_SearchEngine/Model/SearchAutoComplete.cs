using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lucene.Net.Store;
using Lucene.Net.Index;
using Lucene.Net.Search;
using SpellChecker.Net.Search.Spell;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis.NGram;
using Lucene.Net.Documents;

namespace IFN647_SearchEngine.Model
{
    public class SearchAutoComplete
    {
        public int MaxResults { get; set; }

        private class AutoCompleteAnalyzer : Analyzer
        {
            public override TokenStream TokenStream(string fieldName, System.IO.TextReader reader)
            {
                TokenStream result = new StandardTokenizer(kLuceneVersion, reader);

                result = new StandardFilter(result);
                result = new LowerCaseFilter(result);
                result = new ASCIIFoldingFilter(result);
                result = new StopFilter(false, result, StopFilter.MakeStopSet(kEnglishStopWords));
                //DEFAULT_SIDE = Side.FRONT
                result = new EdgeNGramTokenFilter(
                    result, Lucene.Net.Analysis.NGram.EdgeNGramTokenFilter.DEFAULT_SIDE, 1, 20);

                return result;
            }
        }

        private static readonly Lucene.Net.Util.Version kLuceneVersion = Lucene.Net.Util.Version.LUCENE_29;

        private static readonly String kGrammedWordsField = "words";

        private static readonly String kSourceWordField = "sourceWord";

        private static readonly String kCountField = "count";

        private static readonly String[] kEnglishStopWords = {
            "a", "an", "and", "are", "as", "at", "be", "but", "by",
            "for", "i", "if", "in", "into", "is",
            "no", "not", "of", "on", "or", "s", "such",
            "t", "that", "the", "their", "then", "there", "these",
            "they", "this", "to", "was", "will", "with"
        };

        private readonly Directory m_directory;

        private IndexReader m_reader;

        private IndexSearcher m_searcher;

        public SearchAutoComplete(string autoCompleteDir) :
            this(FSDirectory.Open(new System.IO.DirectoryInfo(autoCompleteDir)))
        {
        }
        //Initialize SearchAutoComplete from document index, and max result
        public SearchAutoComplete(Directory autoCompleteDir, int maxResults = 8)
        {
            this.m_directory = autoCompleteDir;
            MaxResults = maxResults;
            ReplaceSearcher();
        }

        /// <summary>
        /// Find terms matching the given partial word that appear in the highest number of documents.</summary>
        /// <param name="term">A word or part of a word</param>
        /// <returns>A list of suggested completions</returns>
        public string[] SuggestTermsFor(string term)
        {
            if (m_searcher == null)
                return new string[] { };

            // get the top terms for query
            Query query = new TermQuery(new Term(kGrammedWordsField, term.ToLower()));
            Sort sort = new Sort(new SortField(kCountField, SortField.INT));

            TopDocs docs = m_searcher.Search(query, null, MaxResults, sort);
            string[] suggestions = docs.ScoreDocs.Select(doc =>
                m_reader.Document(doc.Doc).Get(kSourceWordField)).ToArray();

            return suggestions;
        }


        /// <summary>
        /// Open the index in the given directory and create a new index of word frequency for the 
        /// given index.</summary>
        /// <param name="sourceDirectory">Directory containing the index to count words in.</param>
        /// <param name="fieldToAutocomplete">The field in the index that should be analyzed.</param>
        public void BuildAutoCompleteIndex(Directory sourceDirectory, String fieldToAutocomplete)
        {
            // build a dictionary (from the spell package)
            using (IndexReader sourceReader = IndexReader.Open(sourceDirectory, true))
            {
                //Read words from Lucene Index Directory
                LuceneDictionary dict = new LuceneDictionary(sourceReader, fieldToAutocomplete);

                // use a custom analyzer so we can do EdgeNGramFiltering
                var analyzer = new AutoCompleteAnalyzer();
                using (var writer = new IndexWriter(m_directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED))
                {
                    writer.MergeFactor = 300;
                    writer.SetMaxBufferedDocs(150);

                    // go through every word, storing the original word (incl. n-grams) 
                    // and the number of times it occurs
                    foreach (string word in dict)
                    {
                        if (word.Length < 3)
                            continue; // too short --> bail,  but "too long" is fine...

                        // ok index the word
                        // use the number of documents this word appears in
                        int freq = sourceReader.DocFreq(new Term(fieldToAutocomplete, word));
                        var doc = MakeDocument(fieldToAutocomplete, word, freq);

                        writer.AddDocument(doc);
                    }

                    writer.Optimize();
                }

            }

            // re-open our reader
            ReplaceSearcher();
        }

        //Index original term, grammed, count
        private static Document MakeDocument(String fieldToAutocomplete, string word, int frequency)
        {
            
            var doc = new Document();
            doc.Add(new Field(kSourceWordField, word, Field.Store.YES,
                    Field.Index.NOT_ANALYZED)); // orig term
            doc.Add(new Field(kGrammedWordsField, word, Field.Store.YES,
                    Field.Index.ANALYZED)); // grammed
            doc.Add(new Field(kCountField,
                    frequency.ToString(), Field.Store.NO,
                    Field.Index.NOT_ANALYZED)); // count
            return doc;
        }

        //Create IndexReader from document index directory
        private void ReplaceSearcher()
        {
            
            if (IndexReader.IndexExists(m_directory))
            {
                if (m_reader == null)
                    m_reader = IndexReader.Open(m_directory, true);
                else
                    m_reader.Reopen();

                m_searcher = new IndexSearcher(m_reader);
            }
            else
            {
                m_searcher = null;
            }
        }
    }
}
