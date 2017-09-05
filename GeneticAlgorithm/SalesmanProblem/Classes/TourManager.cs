using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanProblem.Classes
{
    public class TourManager
    {
        //Holds our cities
        private static List<City> destinationCities = new List<City>();

        //Adds a destination city
        public static void AddCity(City city)
        {
            destinationCities.Add(city);
        }

        //Get a city
        public static City GetCity(int index)
        {
            return (City)destinationCities[index];
        }

        //Get the number of destination cities
        public static int NumberOfCities()
        {
            return destinationCities.Count;
        }
    }
}
