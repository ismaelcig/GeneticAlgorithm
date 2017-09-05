using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm.Classes
{
    public class Individual
    {
        static int defaultGeneLength = 64;
        private byte[] genes = new byte[defaultGeneLength];
        //Cache
        private int fitness = 0;
        Random rnd = new Random();

        //Create a random individual
        public void GenerateIndividual()
        {
            for (int i = 0; i < Size(); i++)
            {
                byte gene = (byte)Math.Round(rnd.NextDouble());
                genes[i] = gene;
            }
        }

        #region Getters and Setters
        //Use this if you want to create individuals with different gene lengths
        public static void SetDefaultGeneLength(int length)
        {
            defaultGeneLength = length;
        }

        public byte GetGene(int index)
        {
            return genes[index];
        }

        public void SetGene(int index, byte value)
        {
            genes[index] = value;
            fitness = 0;
        }

        public byte[] GetGenes()
        {
            return genes;
        }
        #endregion

        #region Public Methods
        public int Size()
        {
            return genes.Length;
        }

        public int GetFitness()
        {
            if (fitness == 0)
            {
                fitness = FitnessCalc.GetFitness(this);
            }
            return fitness;
        }

        public override string ToString()
        {
            string genestring = "";
            for (int i = 0; i < Size(); i++)
            {
                genestring += GetGene(i);
            }
            return genestring;
        }
        #endregion
    }
}
