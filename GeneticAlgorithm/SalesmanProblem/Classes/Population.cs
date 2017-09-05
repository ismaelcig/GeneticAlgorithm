using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanProblem.Classes
{
    public class Population
    {
        //Holds population of tours
        Tour[] tours;

        //Construct a population
        public Population(int populationSize, bool initialise)
        {
            tours = new Tour[populationSize];
            //If we need to initialise a population of tours
            if (initialise)
            {
                //Loop and create individuals
                for (int i = 0; i < PopulationSize(); i++)
                {
                    Tour newTour = new Tour();
                    newTour.GenerateIndividual();
                    SaveTour(i, newTour);
                }
            }
        }

        //Saves a tour
        public void SaveTour(int index, Tour tour)
        {
            tours[index] = tour;
        }

        //Gets a tour from population
        public Tour GetTour(int index)
        {
            return tours[index];
        }

        //Gets the best tour in the population
        public Tour GetFittest()
        {
            Tour fittest = tours[0];
            //Loop through individuals to find fittest
            for (int i = 1; i < PopulationSize(); i++)
            {
                if (fittest.GetFitness() <= GetTour(i).GetFitness())
                {
                    fittest = GetTour(i);
                }
            }
            return fittest;
        }

        //Gets population size
        public int PopulationSize()
        {
            return tours.Length;
        }
    }
}
