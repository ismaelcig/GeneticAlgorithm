using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanProblem.Classes
{
    public class Tour
    {
        //Holds our tour of cities
        private List<City> tour = new List<City>();
        //Cache
        private double fitness = 0;
        private int distance = 0;

        //Constructs a blank tour
        public Tour()
        {
            for (int i = 0; i < TourManager.NumberOfCities(); i++)
            {
                tour.Add(null);
            }
        }

        public Tour(List<City> tour)
        {
            this.tour = tour;
        }

        //Creates a random individual
        public void GenerateIndividual()
        {
            //Loop through all our destination cities and add them to our tour
            for (int cityIndex = 0; cityIndex < TourManager.NumberOfCities(); cityIndex++)
            {
                SetCity(cityIndex, TourManager.GetCity(cityIndex));
            }
            //Randomly reorder the tour
            //Console.WriteLine("Tour: \t  " + this.ToString());
            AuxClass.Shuffle(tour);
            //Console.WriteLine("Shuffled: " + this.ToString());
        }

        //Gets a city from the tour
        public City GetCity(int tourPosition)
        {
            return tour[tourPosition];
        }

        //Sets a city in a certain position within a tour
        public void SetCity(int tourPosition, City city)
        {
            tour[tourPosition] = city;
            //If the tours been altered we need to reset the fitness and distance
            fitness = 0;
            distance = 0;
        }

        //Gets the tours fitness
        public double GetFitness()
        {
            if (fitness == 0)
            {
                fitness = 1 / (double)GetDistance();
            }
            return fitness;
        }

        //Gets the total distance of the tour
        public int GetDistance()
        {
            if (distance == 0)
            {
                int tourDistance = 0;
                //Loop through our tour's cities
                for (int cityIndex = 0; cityIndex < TourSize(); cityIndex++)
                {
                    //Get the city we're travelling from
                    City fromCity = GetCity(cityIndex);
                    //City we're travelling to
                    City destinationCity;
                    //Check we're not on our tour's last city, if we are set our 
                    //tour's final destination city to our starting city
                    if (cityIndex + 1 < TourSize())
                    {
                        destinationCity = GetCity(cityIndex + 1);
                    }
                    else
                    {
                        destinationCity = GetCity(0);
                    }
                    //Get the distance between the two cities
                    tourDistance += Convert.ToInt32(Math.Round(fromCity.DistanceTo(destinationCity)));
                }
                distance = tourDistance;
            }
            return distance;
        }

        //Get number of cities on our tour
        public int TourSize()
        {
            return tour.Count;
        }

        //Check if the tour contains a city
        public bool ContainsCity(City city)
        {
            return tour.Contains(city);
        }



        public override string ToString()
        {
            string geneString = "|";
            for (int i = 0; i < TourSize(); i++)
            {
                geneString += GetCity(i) + "|";
            }
            return geneString;
        }

        
    }
}
