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
            //kopiowanie chromosomów
            //mutowanie kopii
            //wybieranie najlepszych
                //W pętli takiej, że best == 0 lub best nie zmieniło się od NumberOfIterationsWithoutProgress iteracji
            return null;
        }
        private void GenerateChromosomes()//można zrobić, żę zwraca obecnie najlepszy, i na tej podstawie ustawiać CurrentBest
        {
            Chromosomes = new List<Chromosome>();
            for (int i = 0; i < NumberOfChromosomes; i++)
                Chromosomes.Add(new Chromosome(NumberOfGenes));
        }
        private void ChooseBestChromosomes()//można zrobić, żę zwraca obecnie najlepszy
        {
            throw new NotImplementedException("Genome.ChooseBestChromosomes");
        }
    }
}
