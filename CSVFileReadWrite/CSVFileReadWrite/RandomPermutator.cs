using System;
using System.Linq;

namespace CSVFileReadWrite
{
    static class RandomPermutator
    {
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
