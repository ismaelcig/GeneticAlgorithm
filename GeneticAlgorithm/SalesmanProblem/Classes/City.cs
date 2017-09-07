using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanProblem.Classes
{
    public class City
    {
        int x;
        int y;
        string name;

        #region Constructors
        //Constructs a randomly placed city
        public City()
        {
            Random rnd = new Random();
            this.x = (int)(rnd.NextDouble() * 200);
            this.y = (int)(rnd.NextDouble() * 200);
            this.name = "|" + x + ", " + y + "|";
        }

        //Constructs a city at chosen x/y location
        public City(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Constructs a city at chosen x/y location with name
        public City(string name, int x, int y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }
        #endregion

        #region Getters
        //Gets city's x coordinate
        public int GetX()
        {
            return this.x;
        }

        //Gets city's y coordinate
        public int GetY()
        {
            return this.y;
        }

        //Get's city's name
        public string GetName()
        {
            return this.name;
        }

        //Gets the distance to given city
        public double DistanceTo(City city)
        {
            int xDistance = Math.Abs(GetX() - city.GetX());
            int yDistance = Math.Abs(GetY() - city.GetY());
            double distance = Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

            return distance;
        }
        #endregion

        public override string ToString()
        {
            //return GetX() + ", " + GetY();
            return name;
        }
    }
}
