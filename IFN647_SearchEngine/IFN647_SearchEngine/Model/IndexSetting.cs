using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Documents;

namespace IFN647_SearchEngine.Model
{
    public class IndexSetting
    {
        public const int STANDARD_ANALYZER = 0;
        public const int SIMPLE_ANALYZER = 1;
        public int Analyzer { get; set; }
        public Field.Store Store { get; set; }
        public Field.Index IndexField { get; set; }
        public Field.TermVector TermVector { get; set; }
        public IndexSetting()
        {
            Analyzer = STANDARD_ANALYZER;
            Store = Field.Store.YES;
            IndexField = Field.Index.ANALYZED;
            TermVector = Field.TermVector.WITH_OFFSETS;

        }
        public override string ToString()
        {
            string result = "Index Setting:\r\n\tAnalyzer: ";
            switch (Analyzer)
            {
                case IndexSetting.STANDARD_ANALYZER:
                    result += "Standard Analyzer\r\n";
                    break;
                case IndexSetting.SIMPLE_ANALYZER:
                    result += "Simple Analyzer\r\n";
                    break;
            }
            result += "\tStore: ";
            switch (Store)
            {
                case Field.Store.YES:
                    result += "YES\r\n";
                    break;
                case Field.Store.NO:
                    result += "NO\r\n";
                    break;

            }
            result += "\tIndex: ";
            switch (IndexField)
            {
                case Field.Index.NO:
                    result += "NO\r\n";
                    break;
                case Field.Index.ANALYZED:
                    result += "ANALYZED\r\n";
                    break;
                case Field.Index.NOT_ANALYZED:
                    result += "NOT ANALYZED\r\n";
                    break;
                case Field.Index.NOT_ANALYZED_NO_NORMS:
                    result += "NOT ANALYZED NO NORMS\r\n";
                    break;
                case Field.Index.ANALYZED_NO_NORMS:
                    result += "ANALYZED NO NORMS\r\n";
                    break;
            }
            result += "\tTermVector: ";
            switch (TermVector)
            {
                case Field.TermVector.NO:
                    result += "NO\r\n";
                    break;
                case Field.TermVector.YES:
                    result += "YES\r\n";
                    break;
                case Field.TermVector.WITH_POSITIONS:
                    result += "WITH POSITIONS\r\n";
                    break;
                case Field.TermVector.WITH_OFFSETS:
                    result += "WITH OFFSETS\r\n";
                    break;
                case Field.TermVector.WITH_POSITIONS_OFFSETS:
                    result += "WITH POSITIONS OFFSETS\r\n";
                    break;
            }
            return result;
        }
    }
}
