using System;
using System.Linq;

namespace CSVFileReadWrite
{
    static class Permutator
    {
        public static int[] GetNextGreedyPermutation(int[] originalMatrix)
        {
            // нужно ли создавать tmp ???
            int[] tmp = new int[originalMatrix.Length];
            Array.Copy(originalMatrix, tmp, originalMatrix.Length);

            Shuffle(tmp);

            return tmp;
        }
        public static void Swap(int[] source, int index1, int index2)
        {
            int temp = source[index1];
            source[index1] = source[index2];
            source[index2] = temp;
        }

        public static int[] GetRandomPermutation(int[] originalMatrix)
        {
            // нужно ли создавать tmp ???
            int[] tmp = new int[originalMatrix.Length];
            Array.Copy(originalMatrix, tmp, originalMatrix.Length);
            
            Shuffle(tmp);

            return tmp;
        }
        
        public static void Shuffle(int[] array)
        {
            Random random = new Random();
            int n = array.Count();
            while (n > 1)
            {
                n--;
                int i = random.Next(n + 1);
                int temp = array[i];
                array[i] = array[n];
                array[n] = temp;
            }
        }
    }
}
