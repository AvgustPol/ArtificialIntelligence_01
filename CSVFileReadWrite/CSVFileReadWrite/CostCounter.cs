
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileReadWrite
{
    static class CostCounter
    {
        //TODO - удалить CostCounter класс и сделать его где-то в другом месте !!!

        public static int CountCost(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    result += StaticMatrixObject.GetFlow(array[i], array[j]) * StaticMatrixObject.GetDistance(i, j);
                }
            }
            return result;
        }
    }
}
