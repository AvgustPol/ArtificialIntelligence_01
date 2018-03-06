using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileReadWrite
{
    static class StaticMatrixObject
    {
        static public int[,] distanceMatrix;
        static public int[,] flowMatrix;

        public static int GetFlow(int i, int j)
        {
            return flowMatrix[i, j];
        }

        public static int GetDistance(int i, int j)
        {
            return distanceMatrix[i, j];
        }
    }
}
