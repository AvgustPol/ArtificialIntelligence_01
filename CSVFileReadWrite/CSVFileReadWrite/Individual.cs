using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileReadWrite
{
    class Individual : ICloneable
    {
        public int Cost { get; set; }
        public int[] Permutation { get; set; }

        public object Clone()
        {
            Individual clone = new Individual();
            clone.Cost = Cost;
            clone.Permutation = (int[])Permutation.Clone();
            return clone;
        }
    }
}
