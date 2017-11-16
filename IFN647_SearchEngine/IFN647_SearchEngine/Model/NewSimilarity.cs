using Lucene.Net.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFN647_SearchEngine.Model
{
    public class NewSimilarity: DefaultSimilarity
    {
        //Override Lucene term frequency
        public override float Tf(int freq)
        {
            //BM25 term frequency score
            //The score approaches (k + 1) asymptotically (here k=1.2)
            //Classic Lucene tf, on the other hand, constantly increases and never reaches a saturation point.
            float k = 1.2f;
            return ((k + 1) * freq) / (k + freq);
        }

    }
}
