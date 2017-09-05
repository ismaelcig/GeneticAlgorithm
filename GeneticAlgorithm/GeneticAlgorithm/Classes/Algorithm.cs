using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Classes
{
    public class Algorithm
    {
        #region GA parameters
        private static readonly double uniformRate = 0.5;
        private static readonly double mutationRate = 0.015;
        private static readonly int tournamentSize = 5;
        private static readonly bool elitism = true;
        #endregion

        #region Public Methods
        //Evolve a population
        public static Population EvolvePopulation(Population pop)
        {
            Population newPopulation = new Population(pop.Size(), false);
            //Keep our best individual
            if (elitism)
            {
                newPopulation.SaveIndividual(0, pop.GetFittest());
            }

            //Crossover population
            int elitismOffset;
            if (elitism)
            {
                elitismOffset = 1;
            }
            else
            {
                elitismOffset = 0;
            }
            // Loop over the population size and create new individuals with crossover
            for (int i = elitismOffset; i < pop.Size(); i++)
            {
                Individual indiv1 = TournamentSelection(pop);
                Individual indiv2 = TournamentSelection(pop);
                Individual newIndiv = Crossover(indiv1, indiv2);
                newPopulation.SaveIndividual(i, newIndiv);
            }

            //Mutate population
            for (int i = elitismOffset; i < newPopulation.Size(); i++)
            {
                Mutate(newPopulation.GetIndividual(i));
            }
            return newPopulation;
        }

        //Crossover individuals
        public static Individual Crossover(Individual indiv1, Individual indiv2)
        {
            Individual newSol = new Individual();
            Random rnd = new Random();
            //Loop through genes
            for (int i = 0; i < indiv1.Size(); i++)
            {
                //Crossover
                if (rnd.NextDouble() <= uniformRate)
                {
                    newSol.SetGene(i, indiv1.GetGene(i));
                }
                else
                {
                    newSol.SetGene(i, indiv2.GetGene(i));
                }
            }
            return newSol;
        }

        //Mutate an individual
        private static void Mutate(Individual indiv)
        {
            Random rnd = new Random();
            //Loop through genes
            for (int i = 0; i < indiv.Size(); i++)
            {
                if (rnd.NextDouble() <= mutationRate)
                {
                    //Create random gene
                    byte gene = (byte)Math.Round(rnd.NextDouble());
                    indiv.SetGene(i, gene);
                }
            }
        }

        //Select individuals for crossover
        private static Individual TournamentSelection(Population pop)
        {
            Random rnd = new Random();
            //Create a tournament population
            Population tournament = new Population(tournamentSize, false);
            //For each place in the tournament get a random individual
            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = (int)(rnd.NextDouble() * pop.Size());
                tournament.SaveIndividual(i, pop.GetIndividual(randomId));
            }
            //Get the fittest
            Individual fittest = tournament.GetFittest();
            return fittest;
        }

        #endregion
    }
}
