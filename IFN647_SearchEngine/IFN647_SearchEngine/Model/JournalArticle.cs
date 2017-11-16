using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN647_SearchEngine
{
    public class JournalArticle
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Bibliographic { get; set; }
        public string Words { get; set; }
        //Read Journal Article from given file
        public JournalArticle(string filename)
        {
            System.IO.TextReader reader = new System.IO.StreamReader(filename);
            //Read the whole file
            string text = reader.ReadToEnd();
            Parse(text);
            reader.Close();
        }

        //Parse input file into ID, Title, Author, Bibliographic, Words
        private void Parse(string text)
        {
            int start = text.IndexOf(".I");
            int end = text.IndexOf(".T");
            //parse id
            ID = text.Substring(start + 3, end-start-4);
            //Parse title
            start = end;
            end = text.IndexOf(".A");
            Title = text.Substring(start + 3, end - start - 3);
            //Parse Author
            start = end;
            end = text.IndexOf(".B");
            Author = text.Substring(start + 3, end - start - 3);
            //Parse Biblio
            start = end;
            end = text.IndexOf(".W");
            Bibliographic = text.Substring(start + 3, end - start - 3);
            //Parse Words
            //Remove title which is included in the words of abstract
            start = end;
            Words = text.Substring(start + 3 + Title.Length);         
        }
    }
}
