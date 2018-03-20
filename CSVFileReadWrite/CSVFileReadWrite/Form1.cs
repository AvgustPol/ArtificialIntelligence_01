using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSVFileReadWrite
{
    public partial class FormMain : Form
    {

        readonly int POPULATIONS_NUMBER = 100;
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

        /*
        public void GreedyPermutationAlgorythm()
        {
            #region Define data
            int arraySize = dataFileReader.myObject.Dimension;
            int[] bestIndexesArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                bestIndexesArray[i] = i;
            }

            //create random permtation as base
            bestIndexesArray = Permutator.GetRandomPermutation(bestIndexesArray);
            ExcelWorker excel = new ExcelWorker("Greedy alg");
            #endregion

            
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    int[] tmp = new int[arraySize];
                    Array.Copy(bestIndexesArray, tmp, arraySize);

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
        */

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

        private void buttonGA_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            #region Create and add name of colums to excel
            ExcelWorker excel = new ExcelWorker("GA alg");
            excel.AddStringCellToWorksheetIntoColumnsABCD("Generation number", "Best individual cost", "Average cost", "Worst cost");
            #endregion
            
            List<AverageCounter> populationDataList = new List<AverageCounter>();

            for (int i = 0; i < POPULATIONS_NUMBER; i++)
            {
                Population population = new Population(StaticMatrixObject.Dimension);
                populationDataList.Add(population.RunAlgorythmWithCounterCondition());
            }

            AverageCounter allPopulationsAverage = new AverageCounter();
            int populationSize = populationDataList[0].generationCounterList.Count;
            for (int i = 0; i < populationSize; i++)
            {
                double generationCounterList = SumElementsAndCountAverageOfAverageGenerationCounterList(populationDataList, i);
                double bestIndividualCostList = SumElementsAndCountAverageOfBest(populationDataList, i);
                double averageCostList = SumElementsAndCountAverageOfAverage(populationDataList, i);
                double worstCostList = SumElementsAndCountAverageOfAverageWorst(populationDataList, i);

                allPopulationsAverage.SaveData(generationCounterList, bestIndividualCostList, averageCostList, worstCostList);
            }

            for (int i = 0; i < populationSize; i++)
            {
                excel.AddCellToWorksheetIntoColumnsABCD<double>(
                    allPopulationsAverage.generationCounterList[i],
                    allPopulationsAverage.bestIndividualCostList[i],
                    allPopulationsAverage.averageCostList[i],
                    allPopulationsAverage.worstCostList[i]
                    );
            }

            #region Standard count
            ExcelWorker excelStandardDeviations = new ExcelWorker("GA alg standard deviations");
            excelStandardDeviations.AddStringCellToWorksheetIntoColumnsABCD("Generation number", "Best individual cost", "Average cost", "Worst cost");

            double best, average, worst;

            for (int q = 0; q < POPULATIONS_NUMBER; q++)
            {
                double[] allPopulationVariablesBest = new double[POPULATIONS_NUMBER];
                for (int w = 0; w < populationDataList.Count; w++)
                {
                    allPopulationVariablesBest[w] = populationDataList[w].bestIndividualCostList[q];
                }
                best = StandardDeviationCounter.CountStandardDeviation(allPopulationsAverage.bestIndividualCostList[q], allPopulationVariablesBest);

                double[] allPopulationVariablesAverage = new double[POPULATIONS_NUMBER];
                for (int w = 0; w < populationDataList.Count; w++)
                {
                    allPopulationVariablesAverage[w] = populationDataList[w].averageCostList[q];
                }
                average = StandardDeviationCounter.CountStandardDeviation(allPopulationsAverage.bestIndividualCostList[q], allPopulationVariablesAverage);

                double[] allPopulationVariablesWorst = new double[POPULATIONS_NUMBER];
                for (int w = 0; w < populationDataList.Count; w++)
                {
                    allPopulationVariablesWorst[w] = populationDataList[w].worstCostList[q];
                }
                worst = StandardDeviationCounter.CountStandardDeviation(allPopulationsAverage.bestIndividualCostList[q], allPopulationVariablesWorst);

                excelStandardDeviations.AddCellToWorksheetIntoColumnsABCD(q, best, average, worst); 
            }

            #endregion
            timer.Stop();
            textBoxTime.Text = $"Czas = {timer.ElapsedMilliseconds}ms.";
        }

        private double SumElementsAndCountAverageOfAverage(List<AverageCounter> list, int index)
        {
            double sum = 0;
            foreach (var item in list)
            {
                sum += item.averageCostList[index];
            }
            return sum / list.Count;
        }

        private double SumElementsAndCountAverageOfBest(List<AverageCounter> list, int index)
        {
            double sum = 0;
            foreach (var item in list)
            {
                sum += item.bestIndividualCostList[index];
            }
            return sum / list.Count;
        }

        private double SumElementsAndCountAverageOfAverageWorst(List<AverageCounter> list, int index)
        {
            double sum = 0;
            foreach (var item in list)
            {
                sum += item.worstCostList[index];
            }
            return sum / list.Count;
        }

        private double SumElementsAndCountAverageOfAverageGenerationCounterList(List<AverageCounter> list, int index)
        {
            double sum = 0;
            foreach (var item in list)
            {
                sum += item.generationCounterList[index];
            }
            return sum / list.Count;
        }

        private double CountAverageInt(List<int> list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum/list.Count;
        }
    }
}