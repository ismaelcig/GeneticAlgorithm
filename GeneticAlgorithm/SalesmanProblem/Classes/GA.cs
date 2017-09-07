using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanProblem.Classes
{
    public class GA
    {
        #region GA parameters
        private static readonly double mutationRate = 0.05;
        private static readonly int tournamentSize = 3;
        private static readonly bool elitism = true;
        #endregion

        //Evolves a population over one generation
        public static Population EvolvePopulation(Population pop)
        {
            Population newPopulation = new Population(pop.PopulationSize(), false);

            //Keep our best individual if elitism is enabled
            int elitismOffset = 0;
            if (elitism)
            {
                newPopulation.SaveTour(0, pop.GetFittest());
                elitismOffset = 1;
            }

            //Crossover population
            //Loop over the new population's size and create individuals from current population
            for (int i = elitismOffset; i < newPopulation.PopulationSize(); i++)
            {
                //Select parents
                Tour parent1 = TournamentSelection(pop);
                Tour parent2 = TournamentSelection(pop);
                //Crossover parents
                Tour child = Crossover(parent1, parent2);
                //Add child to new population
                newPopulation.SaveTour(i, child);
            }

            //Mutate the new population a bit to add some new genetic material
            for (int i = elitismOffset; i < newPopulation.PopulationSize(); i++)
            {
                Mutate(newPopulation.GetTour(i));
            }
            return newPopulation;
        }

        //Applies crossover to a set of parents and creates offspring
        public static Tour Crossover(Tour parent1, Tour parent2)
        {
            //Console.WriteLine("Crossover:");
            //Console.WriteLine("P1: " + parent1);
            //Console.WriteLine("P1: " + parent2);
            //Create new child tour
            Tour child = new Tour();

            //Get start and end sub tour positions for parent1's tour
            int startPos = AuxClass.rnd.Next(parent1.TourSize());
            int endPos = AuxClass.rnd.Next(parent2.TourSize());
            //Console.WriteLine("rnd1: " + startPos);
            //Console.WriteLine("rnd2: " + endPos);

            //Loop and add the sub tour from parent1 to our child
            for (int i = 0; i < child.TourSize(); i++)
            {
                //If our start position is less than the end position
                if (startPos < endPos && i > startPos && i < endPos)
                {
                    child.SetCity(i, parent1.GetCity(i));
                }
                else if (startPos > endPos)
                {
                    if (!(i < startPos && i > endPos))
                    {
                        child.SetCity(i, parent1.GetCity(i));
                    }
                }
            }

            //Loop through parent2's city tour
            for (int i = 0; i < parent2.TourSize(); i++)
            {
                //If child doesn't have the city, add it
                if (!child.ContainsCity(parent2.GetCity(i)))
                {
                    //Loop to find a spare position in the child's tour
                    for (int ii = 0; ii < child.TourSize(); ii++)
                    {
                        if (child.GetCity(ii) == null)
                        {//Spare position found, add city
                            child.SetCity(ii, parent2.GetCity(i));
                            break;
                        }
                    }
                }
            }
            //Console.WriteLine("Child: " + child);
            return child;
        }

        //Mutate a tour using swap mutation
        private static void Mutate(Tour tour)
        {
            //Console.WriteLine("Mutate: " + tour);
            //Loop through tour cities
            for (int tourPos1 = 0; tourPos1 < tour.TourSize(); tourPos1++)
            {
                //Apply mutation rate
                double r = AuxClass.rnd.NextDouble();
                if (r < mutationRate)
                {
                    //Get a second random position in the tour
                    int tourPos2 = AuxClass.rnd.Next(tour.TourSize());

                    //Get the cities at target position in tour
                    City city1 = tour.GetCity(tourPos1);
                    City city2 = tour.GetCity(tourPos2);

                    //Swap them around
                    tour.SetCity(tourPos2, city1);
                    tour.SetCity(tourPos1, city2);
                }
            }
            //Console.WriteLine("Mutated: " + tour);
        }


        //Selects candidate tour for crossover
        private static Tour TournamentSelection(Population pop)
        {
            //Create a tournament population
            Population tournament = new Population(tournamentSize, false);
            //For each place in the tournament get a random candidate tour and add it
            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = AuxClass.rnd.Next(pop.PopulationSize());
                tournament.SaveTour(i, pop.GetTour(randomId));
            }
            //Get the fittest tour
            Tour fittest = tournament.GetFittest();
            //Console.WriteLine("Tournament: " + fittest);
            return fittest;
        }
    }
}
