using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Classes
{
    public class Population
    {
        Individual[] individuals;

        #region Constructors
        //Create a population
        public Population(int populationSize, bool initialise)
        {
            individuals = new Individual[populationSize];
            //Initialise population
            if (initialise)
            {
                //Loop and create individuals
                for (int i = 0; i < Size(); i++)
                {
                    Individual newIndividual = new Individual();
                    newIndividual.GenerateIndividual();
                    SaveIndividual(i, newIndividual);
                }
            }
        }
        #endregion

        #region Getters
        public Individual GetIndividual(int index)
        {
            return individuals[index];
        }

        public Individual GetFittest()
        {
            Individual fittest = individuals[0];
            //Loop through individuals to find fittest
            for (int i = 0; i < Size(); i++)
            {
                if (fittest.GetFitness() <= GetIndividual(i).GetFitness())
                {
                    fittest = GetIndividual(i);
                }
            }
            return fittest;
        }
        #endregion

        #region Public Methods
        //Get population size
        public int Size()
        {
            return individuals.Length;
        }

        //Save individual
        public void SaveIndividual(int index, Individual indiv)
        {
            individuals[index] = indiv;
        }
        #endregion
    }
}
