using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileReadWrite
{
    /// <summary>
    /// Zawiera w sobie dane na temat:
    /// 1 Dimension of matrix
    /// 2 distance Matrix
    /// 3 flow Matrix
    /// </summary>
    class MyObject
    {
        // 1 потому что 0 - это индекс первого числа, которое является числом "измерений" (например 20 -> 20x20) 
        readonly int THE_FIRST_INDEX = 1;
        
        public int Dimension { get; set; }
        public int[,] distanceMatrix;
        public int[,] flowMatrix;

        public MyObject(int dimension, int[,] distanceMatrix, int[,] flowMatrix)
        {
            Dimension = dimension;
            this.distanceMatrix = distanceMatrix;
            this.flowMatrix = flowMatrix;
        }

        public MyObject(int dimension, int[] values)
        {
            Dimension = dimension;
            distanceMatrix = new int[dimension, dimension];
            flowMatrix = new int[dimension, dimension];

            //create flowMatrix
            int index = THE_FIRST_INDEX;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    distanceMatrix[i, j] = values[index];
                    index++;
                }
            }


            //count index in second matrix
            int indexInFlow = THE_FIRST_INDEX + Dimension * Dimension;

            //create distanceMatrix
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    flowMatrix[i, j] = values[index];
                    index++;
                }
            }
        }
        
        public int GetFlow(int i, int j)
        {
            return flowMatrix[i, j];
        }

        public int GetDistance(int i, int j)
        {
            return distanceMatrix[i, j];
        }
    }
}
