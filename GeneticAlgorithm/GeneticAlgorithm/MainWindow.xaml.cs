using GeneticAlgorithm.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneticAlgorithm
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
            Start();
        }
        void Start()
        {
            //We need to set a candidate solution (feel free ti change this if you want to)
            FitnessCalc.SetSolution(new byte[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0,
                                                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                 1, 1, 1, 1 });
            //Create initial population, a population of 50 should be fine
            Population myPop = new Population(50, true);
            int generationCount = 0;
            int bestFittness = 0;
            while (myPop.GetFittest().GetFitness() < FitnessCalc.GetMaxFitness())
            {
                generationCount++;
                if (myPop.GetFittest().GetFitness() > bestFittness)
                {
                    Console.WriteLine("Generation: " + generationCount + " Fittest: " + myPop.GetFittest().GetFitness());
                    Console.WriteLine("Fittest: ");
                    foreach (byte b in myPop.GetFittest().GetGenes())
                    {
                        Console.Write(b);
                    }
                    bestFittness = myPop.GetFittest().GetFitness();
                }
                myPop = Algorithm.EvolvePopulation(myPop);
            }
            Console.WriteLine("Solution found!");
            Console.WriteLine("Generation: " + generationCount);
            Console.WriteLine("Genes: ");
            Console.WriteLine(myPop.GetFittest());
        }
    }
}
