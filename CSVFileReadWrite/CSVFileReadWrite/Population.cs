using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileReadWrite
{
    class Population
    {
        Random random;

        readonly int COUNTER_STOP_CONDITION = 1000; // количество итараций 
        readonly int TIMER_STOP_CONDITION = 5000; // время в милисикундах 

        readonly int POPULATION_SIZE = 10;
        
        readonly int HYBRIDIZATION_PROBABILITY = 20; // x% 
        readonly int MUTATION_PROBABILITY = 10; // x%  
        readonly int MAX_PROBABILITY = 100; // 100%

        List<Individual> individuals;
        public Individual BestIndividual { get; set; }
        public int Dimension { get; set; }

        public Population(int dimension)
        {
            random = new Random((int)DateTime.UtcNow.Ticks);
            Dimension = dimension;
            individuals = new List<Individual>(POPULATION_SIZE);
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                individuals.Add(new Individual());
            }
            BestIndividual = new Individual();

            CreateNewRandomPopulation();
            CountCostForAllIndividuals();
            SaveBest();
        }

        private void CreateNewRandomPopulation()
        {
            #region Create new defualt array {0,1,2,3,4,5, ... , dimension-1}
            int[] defaultArray = new int[Dimension];
            for (int i = 0; i < Dimension; i++)
            {
                defaultArray[i] = i;
            }
            #endregion

            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                individuals.ElementAt(i).Permutation = Permutator.GetRandomPermutation(defaultArray);
            }
        }

        private void CountCostForAllIndividuals()
        {
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                individuals.ElementAt(i).Cost = CostCounter.CountCost(individuals.ElementAt(i).Permutation);
            }

        }
        
        private void DoTournamentSelection()
        {
            List<Individual> tmpIndividuals = new List<Individual>(POPULATION_SIZE);
            
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                int randomIndex1 = random.Next(POPULATION_SIZE - 1);
                int randomIndex2 = random.Next(POPULATION_SIZE - 1);
                while (randomIndex1 == randomIndex2)
                {
                    randomIndex2 = random.Next(POPULATION_SIZE - 1);
                }
                //we are looking for the smalles cost. 
                if (individuals.ElementAt(randomIndex1).Cost > individuals.ElementAt(randomIndex2).Cost)
                {
                    tmpIndividuals.Add(individuals.ElementAt(randomIndex2));
                }
                else
                {
                    tmpIndividuals.Add(individuals.ElementAt(randomIndex1));
                }
            }
            individuals = tmpIndividuals;
        }

        private void DoMultiTournamentSelection(int individualsNumber)
        {
            List<Individual> tmpIndividuals = new List<Individual>(POPULATION_SIZE);

            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                #region Create random indexes 
                int[] randomIndexes = new int[individualsNumber];
                for (int z = 0; z < individualsNumber; z++)
                {
                    randomIndexes[z] = random.Next(POPULATION_SIZE - 1);
                }
                #endregion

                #region Create tmp list of individuals (by random indexes)
                List<Individual> tmpTournamentIndividuals = new List<Individual>();
                foreach (var item in randomIndexes)
                {
                    tmpTournamentIndividuals.Add(individuals.ElementAt(item));
                }
                #endregion

                #region Find best in tmp list
                Individual tmpBest = tmpTournamentIndividuals.First();

                foreach (var item in tmpTournamentIndividuals)
                {
                    if (item.Cost < tmpBest.Cost)
                        tmpBest = item;
                }
                #endregion

                tmpIndividuals.Add(tmpBest);
                
            }
            individuals = tmpIndividuals;
        }

        public class RuletkaPobability
        {
            public int Index { get; set; }
            public decimal Probability { get; set; }
            public RuletkaPobability(int index, decimal probability)
            {
                Index = index;
                Probability = probability;
            }
        }
        
        private void DoRuletkaSelection()
        {
            List<Individual> tmpIndividuals = new List<Individual>(POPULATION_SIZE);
            List<RuletkaPobability> ruletkaList = new List<RuletkaPobability>();
            decimal costSum = 0;
            int counter = 0;
            foreach (var item in individuals)
            {
                costSum += (decimal)(1 / item.Cost);
            }
            foreach (var item in individuals)
            {
                ruletkaList.Add(new RuletkaPobability(counter++, (decimal)(item.Cost / costSum)));
            }

            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                bool found = false;
                while(!found)
                {
                    int randomProbability = random.Next(MAX_PROBABILITY);
                    int randomElement = random.Next(POPULATION_SIZE);
                    if(ruletkaList.ElementAt(randomElement).Probability > randomProbability)
                    {
                        found = true;
                        tmpIndividuals.Add(individuals.ElementAt(randomElement));
                    }
                }
            }

            individuals = tmpIndividuals;
        }

        public void RunAlgorythmWithCounterCondition()
        {
            int counter = 0;
            ExcelWorker excel = new ExcelWorker("GA alg");

            while (COUNTER_STOP_CONDITION > counter)
            {
                CreateNextPopulationCircle();
                
                excel.AddCellToWorksheetIntoColumnsAB(counter++, BestIndividual.Cost);
            }
        }

        private void CreateNextPopulationCircle()
        {
            DoTournamentSelection();
            DoHybridization();
            DoMutation();
            SaveBest();
        }

        private void DoHybridization()
        {
            #region Select pivot
            int pivotIndex = SelectRandomPivot();
            //or at middle :
            //int pivotIndex = Dimension / 2;
            #endregion
            // я не делаю ремонт, потому что я не делаю скрещивание на тех элементах, которых нет на новой таблице
            // зачем ломать , а потом чинить, если можно сразу не ломать ? :)
            CreateNewIndividuals(pivotIndex);
        }

        

        private void CreateNewIndividuals(int pivot)
        {
            int halfPopulation = POPULATION_SIZE / 2;
            for (int i = 0; i < halfPopulation; i += 2)
            {
                int randomNumber = random.Next(MAX_PROBABILITY);
                if (HYBRIDIZATION_PROBABILITY > randomNumber)
                {
                    CreateNewPairIndividuals(pivot, individuals.ElementAt(i), individuals.ElementAt(i + 1));
                }
            }
        }

        private void CreateNewPairIndividuals(int indexTo, Individual firstIndividual, Individual secondIndividual)
        {
            for (int i = 0; i < indexTo; i++)
            {
                if (WasHere(firstIndividual.Permutation, secondIndividual.Permutation.ElementAt(i)))
                {
                    Permutator.SwapBeetweenArrays(firstIndividual.Permutation, secondIndividual.Permutation, i);
                }
            }
        }

        /// <summary>
        /// Checks , if value was in array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool WasHere(int[] array, int value)
        {
            bool wasHere = false;
            foreach (var item in array)
            {
                if (item == value)
                    wasHere = true;
            }
            return wasHere;
        }

        private int SelectRandomPivot()
        {
            int randomPivot = random.Next(1, Dimension - 2);
            return randomPivot;
        }

        private void DoMutation()
        {
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                int randomNumber = random.Next(MAX_PROBABILITY);
                
                if (MUTATION_PROBABILITY > randomNumber)
                {
                    int randomIndex1 = random.Next(Dimension);
                    int randomIndex2 = random.Next(Dimension);
                    while (randomIndex1 == randomIndex2)
                    {
                        randomIndex2 = random.Next(Dimension);
                    }
                    //MUTATE
                    Permutator.Swap(individuals.ElementAt(i).Permutation, randomIndex1, randomIndex2);
                }
            }
        }

        private void SaveBest()
        {
            //check is best still best
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                if (BestIndividual.Cost < individuals.ElementAt(i).Cost)
                {
                    BestIndividual = individuals.ElementAt(i);
                }
            }
        }
    }
}
