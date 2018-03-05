using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSVFileReadWrite
{
    public partial class FormMain : Form
    {
        readonly int MAX_COUNTER_VALUE = 1000000;
        DataFileReader dataFileReader;
        public FormMain()
        {
            InitializeComponent();
            dataFileReader = new DataFileReader(textBoxPathToDataFile.Text);
        }

        private void buttonStartRandom_Click(object sender, EventArgs e)
        {
            RandomPermutationAlgorythm();
        }

        public void RandomPermutationAlgorythm()
        {
            int arraySize = dataFileReader.myObject.Dimension;
            int[] bestIndexesArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                bestIndexesArray[i] = i;
            }
            
            int generationCounter = 0;
            while(generationCounter < MAX_COUNTER_VALUE + 1)
            {
                int[] tmp = RandomPermutator.GetRandomPermutation(bestIndexesArray);

                
                int tmpCost = CountCost(tmp);
                //Debug.Write("tmpCost  = " + tmpCost + " ");
                int mainCost = CountCost(bestIndexesArray);
                //Debug.WriteLine("mainCost = " + mainCost);
                if (tmpCost < mainCost)
                    Array.Copy(tmp, bestIndexesArray, arraySize);

                generationCounter++;
            }
            
            Debug.WriteLine("Cost = " + CountCost(bestIndexesArray));

            string bestResult = "";

            foreach (var item in bestIndexesArray)
            {
                bestResult += item.ToString() + "; ";
            }

            textBoxTotalCost.Text = bestResult;
        }

        public int CountCost(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    result += dataFileReader.myObject.GetFlow(array[i], array[j]) * dataFileReader.myObject.GetDistance(i , j);
                }
            }
            return result;
        }

    }
}