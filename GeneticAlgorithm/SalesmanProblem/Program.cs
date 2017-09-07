using SalesmanProblem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalesmanProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread t = new Thread(DoWork);
            t.Start();
            t.Join();
            Console.ReadLine();
        }

        public static void DoWork()
        { //Create and add our cities
            #region Create Map
            City city = new City("A", 60, 200);
            TourManager.AddCity(city);
            City city2 = new City("B", 180, 200);
            TourManager.AddCity(city2);
            City city3 = new City("C", 80, 180);
            TourManager.AddCity(city3);
            City city4 = new City("D", 140, 180);
            TourManager.AddCity(city4);
            City city5 = new City("E", 20, 160);
            TourManager.AddCity(city5);
            City city6 = new City("F", 100, 160);
            TourManager.AddCity(city6);
            City city7 = new City("G", 200, 160);
            TourManager.AddCity(city7);
            City city8 = new City("H", 140, 140);
            TourManager.AddCity(city8);
            City city9 = new City("I", 40, 120);
            TourManager.AddCity(city9);
            City city10 = new City("J", 100, 120);
            TourManager.AddCity(city10);
            City city11 = new City("K", 180, 100);
            TourManager.AddCity(city11);
            City city12 = new City("L", 60, 80);
            TourManager.AddCity(city12);
            City city13 = new City("M", 120, 80);
            TourManager.AddCity(city13);
            City city14 = new City("N", 180, 60);
            TourManager.AddCity(city14);
            City city15 = new City("Ñ", 20, 40);
            TourManager.AddCity(city15);
            City city16 = new City("O", 100, 40);
            TourManager.AddCity(city16);
            City city17 = new City("P", 200, 40);
            TourManager.AddCity(city17);
            City city18 = new City("Q", 20, 20);
            TourManager.AddCity(city18);
            City city19 = new City("R", 60, 20);
            TourManager.AddCity(city19);
            City city20 = new City("S", 160, 20);
            TourManager.AddCity(city20);
            #endregion
            //Initialize population
            Population pop = new Population(70, true);
            Console.WriteLine("Initial distance: " + pop.GetFittest().GetDistance());
            Console.WriteLine(pop.GetFittest());

            //Evolve population for 100 generations
            pop = GA.EvolvePopulation(pop);
            for (int i = 0; i < 400; i++)
            {
                Console.WriteLine(pop.GetFittest());
                pop = GA.EvolvePopulation(pop);

            }
            Console.WriteLine("Distance: " + pop.GetFittest().GetDistance());
            //while (pop.GetFittest().GetDistance() > 950)
            //{
            //    pop = GA.EvolvePopulation(pop);
            //    Console.WriteLine(pop.GetFittest());
            //    if (Console.ReadLine() == "1")
            //    {
            //        break;
            //    }
            //}

            //Print final results
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Finished");
            Console.WriteLine("Final distance: " + pop.GetFittest().GetDistance());
            Console.WriteLine("Solution");
            Console.WriteLine(pop.GetFittest());

            Console.ReadLine();
        }
    }
}
