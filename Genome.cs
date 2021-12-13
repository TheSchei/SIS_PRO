using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_PRO
{
    class Genome
    {
        private List<Chromosome> Chromosomes;
        private int WindowWidth;
        private int NumberOfGenes;
        private int NumberOfChromosomes;

        private int CurrentBest;

        private int NumberOfIterationsWithoutProgress;


        public Genome(int NumberOfGenes, int WindowWidth)
        {
            this.NumberOfGenes = NumberOfGenes;
            this.WindowWidth = WindowWidth;
            NumberOfChromosomes = 10;
            NumberOfIterationsWithoutProgress = 1000;//orientacyjnie
            GenerateChromosomes();
        }
        public Genome(int NumberOfGenes, int WindowWidth, int NumberOfChromosomes)
        {
            this.NumberOfGenes = NumberOfGenes;
            this.WindowWidth = WindowWidth;
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
                Chromosomes.Add(new Chromosome(NumberOfGenes, WindowWidth));
            CurrentBest = Chromosomes[0].getValue();
            foreach (Chromosome chromosome in Chromosomes)
                if (chromosome.getValue() < CurrentBest)
                    CurrentBest = chromosome.getValue();
        }
        private Chromosome ChooseBestChromosomes()//zwraca obecnie najlepszy
        {
            Chromosomes.Sort((x, y) => x.getValue().CompareTo(y.getValue()));//sprawdzić czy sortuje jak powinno (kolejnosć ma być malejąca)
            Chromosomes.RemoveRange(NumberOfChromosomes, Chromosomes.Count - NumberOfChromosomes);
            return Chromosomes[0];
        }
        private bool SetCurrentBest()//ustawia CurrentBest i zwraca True, jeśli coś się zmieniło
        {
            bool Flag = false;
            foreach (Chromosome chromosome in Chromosomes)
                if (chromosome.getValue() < CurrentBest)
                {
                    CurrentBest = chromosome.getValue();
                    Flag = true;
                }
            return Flag;
        }
    }
}
