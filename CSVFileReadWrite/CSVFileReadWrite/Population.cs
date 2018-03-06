using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVFileReadWrite
{
    class Population
    {
        readonly int NUMBER_OF_PAIRS_TO_HYBRIDIZATION = 3; // 6 osobnikow
        readonly int POPULATION_SIZE = 30;

        readonly int HYBRIDIZATION_PROBABILITY = 5; // 5%  
        readonly int MAX_HYBRIDIZATION_PROBABILITY = 100; // 100%

        List<Individual> individuals;
        public Individual BestIndividual { get; set; }
        public int Dimension { get; set; }

        public Population(int dimension)
        {
            Dimension = dimension;
            individuals = new List<Individual>(POPULATION_SIZE);
            CreateNewRandomPopulation();
            CountCostForAllIndividuals();
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
                individuals.ElementAt<Individual>(i).Permutation = Permutator.GetRandomPermutation(defaultArray);
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
            Random random = new Random();
            
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                int randomIndex1 = random.Next(POPULATION_SIZE - 1);
                int randomIndex2 = random.Next(POPULATION_SIZE - 1);

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

        private void TODOnameMethod()
        {
            DoTournamentSelection();
            //DO_HYBRIDIZATION();
            DoMutation();
            SaveBest();

            TODOnameMethod();
        }

        private void DoMutation()
        {
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                Random random = new Random();
                int randomNumber = random.Next(MAX_HYBRIDIZATION_PROBABILITY);
                
                if (HYBRIDIZATION_PROBABILITY > randomNumber)
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
            Boolean stillBest = true;
            //check is best still best
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                if (BestIndividual.Cost < individuals.ElementAt(i).Cost)
                {
                    BestIndividual = individuals.ElementAt(i);
                    stillBest = false;
                }
            }
        }
    }
}
