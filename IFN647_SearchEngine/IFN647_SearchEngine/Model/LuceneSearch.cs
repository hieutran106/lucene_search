using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Document and Field
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory
using Lucene.Net.Search; // for IndexSearcher
using Lucene.Net.QueryParsers;  // for QueryParser
using SpellChecker.Net.Search.Spell; // for SpellChecker
using IFN647_SearchEngine.Model;
using System.IO;
using Syn.WordNet;

namespace IFN647_SearchEngine
{
    public class LuceneSearch
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzer;

        Lucene.Net.Index.IndexWriter writer;

        Lucene.Net.Search.IndexSearcher searcher;

        Lucene.Net.QueryParsers.QueryParser parser;

        Similarity newSimilarity;

        Lucene.Net.Index.IndexReader indexReader;


        Lucene.Net.Store.Directory spellCheckIndexStorage;
        Lucene.Net.Store.Directory autoCompleteIndexDirectory;

        SpellChecker.Net.Search.Spell.SpellChecker spellchecker;
        SearchAutoComplete searchAutoComplete;

        //Word net library
        WordNetEngine wordNet;

        //object containing all current relevant documents
        public ScoreDoc[] ScoreDocs { get; set; }

        //Lucene version
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;

        //constants names for the fields
        public const string WORD_FN = "Abstract";
        public const string TITLE_FN = "Title";
        public const string ID_FN = "ID";
        public const string AUTHOR_FN = "Author";
        public const string BILI_FN = "Biliography";

        //default options for the analyser
        const Field.Store STORE = Field.Store.YES;
        const Field.Index INDEX_FIELD = Field.Index.ANALYZED;
        const Field.TermVector TERM_VECTOR = Field.TermVector.WITH_OFFSETS;

        //constructor
        public LuceneSearch()
        {
            luceneIndexDirectory = null;
            writer = null;
            searcher = null;
            parser = null;
            ScoreDocs = null;

            //default settings of analyzer: Standard Analyzer, with lower case filter and no stop word filter
            analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(VERSION, new HashSet<string>());

            //changes to Lucene score
            newSimilarity = new NewSimilarity();

        }
        

        /// <summary>
        /// Creates the index at indexPath
        /// </summary>
        /// <param name="indexPath">Directory path to create the index</param>
        public void CreateIndex(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            spellCheckIndexStorage = Lucene.Net.Store.FSDirectory.Open(indexPath + @"\spell");
            autoCompleteIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath+@"\autocomplete");
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);

            //changes to Lucene score
            writer.SetSimilarity(newSimilarity);

        }

        /// <summary>
        /// Indexes the given text
        /// </summary>
        /// <param name="text">Text to index</param>
        public void IndexText(JournalArticle article)
        {
            //Always store document ID regardless of index setting
            Lucene.Net.Documents.Field I_field = new Field(ID_FN, article.ID, STORE, INDEX_FIELD, TERM_VECTOR);
            Lucene.Net.Documents.Field T_field = new Field(TITLE_FN, article.Title, STORE, INDEX_FIELD, TERM_VECTOR);
            Lucene.Net.Documents.Field A_field = new Field(AUTHOR_FN, article.Author, STORE, INDEX_FIELD, TERM_VECTOR);
            Lucene.Net.Documents.Field B_field = new Field(BILI_FN, article.Bibliographic, STORE, INDEX_FIELD, TERM_VECTOR);
            Lucene.Net.Documents.Field W_field = new Field(WORD_FN, article.Words, STORE, INDEX_FIELD, TERM_VECTOR);

            Lucene.Net.Documents.Document doc = new Document();
            doc.Add(I_field);
            doc.Add(T_field);
            doc.Add(A_field);
            doc.Add(B_field);
            doc.Add(W_field);
            writer.AddDocument(doc);
        }

        /// <summary>
        /// Flushes buffer and closes the index
        /// </summary>
        public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }

        //function to set up searcher and parser objects
        public void SetupSearch()
        {
            searcher = new IndexSearcher(luceneIndexDirectory);
            parser = new MultiFieldQueryParser(VERSION, new string[] { WORD_FN, AUTHOR_FN, BILI_FN, TITLE_FN }, analyzer);
        }

        public void CleanUpSearcher()
        {
            searcher.Dispose();
        }


        //function to get the query text after applying parser
        public string GetProcessedQueryText(string input, Boolean removeStopwords)
        {
            HashSet<string> stopWords = new HashSet<string>();
            if (removeStopwords)
            {
                foreach (string word in StopWords.All)
                {
                    stopWords.Add(word);
                }
            }
            //Standard Analyzer, with lower case filter and choice of with or without stopword filter
            Analyzer analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(VERSION, stopWords);
            QueryParser parser = new QueryParser(VERSION, "", analyzer);
            Query query = parser.Parse(input);
            string result = query.ToString();
            return result;
        }

        //function to start searching for relevant documents based on user query
        public int Search(string querytext, string fieldName)
        {
            querytext = querytext.ToLower();
            QueryParser actualParser = parser; ;

            switch(fieldName)
            {
                case WORD_FN:
                    actualParser = new MultiFieldQueryParser(VERSION, new string[] { WORD_FN }, analyzer);
                    break;
                case TITLE_FN:
                    actualParser = new MultiFieldQueryParser(VERSION, new string[] { TITLE_FN }, analyzer);
                    break;
                case AUTHOR_FN:
                    actualParser = new MultiFieldQueryParser(VERSION, new string[] { AUTHOR_FN }, analyzer);
                    break;
                case BILI_FN:
                    actualParser = new MultiFieldQueryParser(VERSION, new string[] { BILI_FN }, analyzer);
                    break;
                case "All":
                default:
                    break;
            }
                
            Query query = actualParser.Parse(querytext);

            TopDocs results = searcher.Search(query, 1400);
            ScoreDocs = results.ScoreDocs;
            if (ScoreDocs != null)
            {
                int result = ScoreDocs.Length/10;
                if ((ScoreDocs.Length % 10) != 0)
                {
                    result++;
                }
                return result;
            }
            return 0;
        }

        //function to get list of 10 documents at each result page
        public List<string[]> GetResultCollection(int index)
        {
            List<string[]> result = new List<string[]>();
            int start = 10 * (index - 1);
            if (ScoreDocs != null)
            {
                for (int i = start; i < (start + 10); i++)
                {
                    if (i >= ScoreDocs.Length)
                    {
                        break;
                    }
                    Document doc = searcher.Doc(ScoreDocs[i].Doc);
                    string[] current = {    "" + (i+1),
                                     doc.Get(TITLE_FN).ToString(),
                                     doc.Get(AUTHOR_FN).ToString(),
                                     doc.Get(BILI_FN).ToString(),
                                     doc.Get(WORD_FN).ToString(),
                                     doc.Get(ID_FN).ToString()};
                    result.Add(current);
                }
            }
            return result;
        }

        //function to append search result to a file
        public void AppendSearchResult(string filePath,int queryId)
        {

            using (StreamWriter stream = File.AppendText(filePath))
            {
                int rank = 1;
                foreach (ScoreDoc scoreDoc in ScoreDocs)
                {
                    //write data to file
                    Document doc = searcher.Doc(scoreDoc.Doc);
                    stream.Write(queryId.ToString("000") + "\tQ0\t" + doc.Get(ID_FN) + "\t" + rank + "\t" + scoreDoc.Score + "\tn09569898_n9813047_n9639799_GGezTTH\n");
                    rank++;
                }

            }
        }

        //function to initialize the spell checker functionality
        public void SpellCheckerInit()
        {
            spellchecker = new SpellChecker.Net.Search.Spell.SpellChecker(spellCheckIndexStorage);

            // To index a field of a user index:
            indexReader = writer.GetReader();
            spellchecker.IndexDictionary(new LuceneDictionary(indexReader, WORD_FN));

        }
            
        //function to return the suggestions from spell checker
        public string[] SpellCheckerSuggestion (string inputQuery)
        {
            String[] suggestions = spellchecker.SuggestSimilar(inputQuery, 5);
            return suggestions;
        }

        //function to return suggestions for single words
        public string SingleWordSuggestion(string inputQuery)
        {
            String[] suggestions = spellchecker.SuggestSimilar(inputQuery, 1);
            if (suggestions.Length != 0)
                return suggestions[0];
            else return "error404";
        }

        //Auto complete
        //function to initialize auto complete functionality
        public void AutoCompleteInit()
        {
            searchAutoComplete = new SearchAutoComplete(autoCompleteIndexDirectory, 3);
            searchAutoComplete.BuildAutoCompleteIndex(luceneIndexDirectory, WORD_FN);
            searchAutoComplete.BuildAutoCompleteIndex(luceneIndexDirectory, TITLE_FN);
        }

        //function to return suggestions from the auto complete functionality
        public string[] AutoCompleteSuggestion(string inputQuery)
        {
            string[] suggestions = searchAutoComplete.SuggestTermsFor(inputQuery);
            return suggestions;
        }

        //Init wordnet
        public void WordNetInit()
        {
            var directory = System.IO.Directory.GetCurrentDirectory();

            wordNet = new WordNetEngine();
            Console.WriteLine("Loading database...");
            wordNet.LoadFromDirectory(directory);
            Console.WriteLine("Load completed.");
        }

        //function to return a list of synonyms of a given word
        public List<string> GetSynonym(string word)
        {
            List<string> result = new List<string>();
            var synSetList = wordNet.GetSynSets(word);
            int count = 0;
            switch (synSetList.Count)
            {
                case 0:
                    break;
                case 1:
                    foreach(string synWord in synSetList[0].Words)
                    {
                        if(synWord.ToLower() != word)
                        {
                            result.Add(synWord.ToLower());
                            count++;
                        }
                        if (count == 3) break;
                    }
                    break;
                default:
                    int number = CountWordinList(synSetList, word);
                    while (number > 0)
                    {
                        foreach (var synSet in synSetList)
                        {
                            foreach(string tmpString in synSet.Words)
                            {
                                if (tmpString.ToLower() != word && !result.Contains(tmpString.ToLower()))
                                {
                                        result.Add(tmpString.ToLower());
                                        number--;
                                        count++;
                                        break;

                                }
                            }
                            if (count == 3) break;
                        }
                        if (count == 3) break;
                    }
                    break;
            }

            //function to remove dashes from string
            for (int i=0;i<result.Count;i++)
            {
                string sym = result[i];
                if (sym.Contains('_')) {
                    string new_sym = sym.Replace('_', ' ');
                    new_sym = "\"" + new_sym + "\"";
                    result[i] = new_sym;
                }
            }
            return result;
        }

        //function to count number of distinct synonyms
        private int CountWordinList (List<SynSet> synSets, string word)
        {
            int count = 0;
            List<string> tmp_word = new List<string>(); ;
            foreach (var synWord in synSets)
            {
                foreach(string tmp in synWord.Words)
                {
                    if(tmp.ToLower()!= word && !tmp_word.Contains(tmp.ToLower()))
                    {
                        tmp_word.Add(tmp.ToLower());
                        count++;
                    }
                        
                }
            }
            return count;
        }
    }
}