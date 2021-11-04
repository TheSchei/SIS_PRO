using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_PRO
{
    class Genome
    {
        private List<Chromosome> Chromosomes;
        private int NumberOfGenes;
        private int NumberOfChromosomes;

        private int CurrentBest;

        private int NumberOfIterationsWithoutProgress;


        public Genome(int NumberOfGenes)
        {
            this.NumberOfGenes = NumberOfGenes;
            NumberOfChromosomes = 10;
            NumberOfIterationsWithoutProgress = 100;//orientacyjnie
            GenerateChromosomes();
        }
        public Genome(int NumberOfGenes, int NumberOfChromosomes)
        {
            this.NumberOfGenes = NumberOfGenes;
            this.NumberOfChromosomes = NumberOfChromosomes;
            GenerateChromosomes();
        }

        public Chromosome Run()
        {
            int iterator = 0;
            while (iterator < NumberOfIterationsWithoutProgress)
            {
                //kopiowanie chromosomów
                List<Chromosome> temp = new List<Chromosome>();
                foreach (Chromosome chromosome in Chromosomes)
                    temp.Add(chromosome.DeepCopy());
                //mutowanie kopii
                foreach (Chromosome chromosome in temp)
                    chromosome.Mutate();
                //wybieranie najlepszych
                Chromosomes.AddRange(temp);
                Chromosome currentBest = ChooseBestChromosomes();

                if (SetCurrentBest()) iterator = 0;
                else iterator++;

                if (CurrentBest == 0) return currentBest;
            }//W pętli takiej, że best == 0 lub best nie zmieniło się od NumberOfIterationsWithoutProgress iteracji
            return null;//nie znaleziono rozwiązania
        }
        private void GenerateChromosomes()//można zrobić, żę zwraca obecnie najlepszy, i na tej podstawie ustawiać CurrentBest
        {
            Chromosomes = new List<Chromosome>();
            for (int i = 0; i < NumberOfChromosomes; i++)
                Chromosomes.Add(new Chromosome(NumberOfGenes));
            SetCurrentBest();
        }
        private Chromosome ChooseBestChromosomes()//zwraca obecnie najlepszy
        {
            throw new NotImplementedException("Genome.ChooseBestChromosomes");
        }
        private bool SetCurrentBest()//ustawia CurrentBest i zwraca True, jeśli coś isę zmieniło
        {
            throw new NotImplementedException("Genome.getCurrentBest");
        }
    }
}
