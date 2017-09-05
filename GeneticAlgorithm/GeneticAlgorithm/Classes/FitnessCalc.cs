using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Classes
{
    public class FitnessCalc
    {
        static byte[] solution = new byte[64];//TODO: Individual.defaultGeneLength

        #region Public Methods
        //Set a candidate solution as a byte array
        public static void SetSolution(byte[] newSolution)
        {
            solution = newSolution;
        }

        //To make it easier we can use this method to set our candidate solution
        //with string of 0s and 1s
        static void SetSolution(string newSolution)
        {
            solution = new byte[newSolution.Length];
            //Loop through each character of our string and save it in our byte array
            for (int i = 0; i < newSolution.Length; i++)
            {
                string character = newSolution.Substring(i, i + 1);
                if (character.Contains("0") || character.Contains("1"))
                {
                    solution[i] = Byte.Parse(character);
                }
                else
                {
                    solution[i] = 0;
                }
            }
        }

        //Calculate individual fitness by comparing it to our candidate solution
        public static int GetFitness(Individual individual)
        {
            int fitness = 0;
            //Loop through our individuals genes and compare them to our candidates
            for (int i = 0; i < individual.Size() && i < solution.Length; i++)
            {
                if (individual.GetGene(i) == solution[i])
                {
                    fitness++;
                }
            }
            return fitness;
        }

        //Get optimum fitness
        public static int GetMaxFitness()
        {
            int maxFitness = solution.Length;
            return maxFitness;
        }
        #endregion
    }
}
