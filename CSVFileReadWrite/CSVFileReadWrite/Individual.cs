﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileReadWrite
{
    class Individual
    {
        public int Cost { get; set; }
        public int[] Permutation { get; set; }
        //PermutationDimension = Permutation.Length
        public int PermutationDimension { get; set; }
        
    }
}