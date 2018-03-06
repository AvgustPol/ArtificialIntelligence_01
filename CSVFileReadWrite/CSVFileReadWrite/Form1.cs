using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSVFileReadWrite
{
    public partial class FormMain : Form
    {
        readonly int MAX_COUNTER_VALUE = 1000;
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

            ExcelWorker excel = new ExcelWorker("Random alg");

            int generationCounter = 1;
            while(generationCounter < MAX_COUNTER_VALUE)
            {
                int[] tmp = Permutator.GetRandomPermutation(bestIndexesArray);
                int tmpCost = CountCost(tmp);
                int mainCost = CountCost(bestIndexesArray);
                if (tmpCost < mainCost)
                    Array.Copy(tmp, bestIndexesArray, arraySize);

                excel.AddCellToWorksheetIntoColumnsAB(generationCounter++, CountCost(bestIndexesArray));
            }

            #region Show result
            string bestResult = "";

            foreach (var item in bestIndexesArray)
            {
                bestResult += item.ToString() + "; ";
            }

            textBoxTotalCost.Text = bestResult;
            #endregion
        }

        public void GreedyPermutationAlgorythm()
        {
            #region Define data
            int arraySize = dataFileReader.myObject.Dimension;
            int[] bestIndexesArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                bestIndexesArray[i] = i;
            }

            bestIndexesArray = Permutator.GetRandomPermutation(bestIndexesArray);
            ExcelWorker excel = new ExcelWorker("Greedy alg");
            #endregion


            //create random permtation as base

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    //swap
                    Permutator.Swap(i , j);

                //count
                //save to log
                }
            }




            int generationCounter = 1;
            while (generationCounter < MAX_COUNTER_VALUE)
            {
                int[] tmp = Permutator.GetRandomPermutation(bestIndexesArray);
                int tmpCost = CountCost(tmp);
                int mainCost = CountCost(bestIndexesArray);
                if (tmpCost < mainCost)
                    Array.Copy(tmp, bestIndexesArray, arraySize);

                excel.AddCellToWorksheetIntoColumnsAB(generationCounter++, CountCost(bestIndexesArray));
            }

            #region Show result
            string bestResult = "";

            foreach (var item in bestIndexesArray)
            {
                bestResult += item.ToString() + "; ";
            }

            textBoxTotalCost.Text = bestResult;
            #endregion
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