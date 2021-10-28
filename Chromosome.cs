using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_PRO
{
    class Chromosome
    {
        //nie wiem jeszcze jak przechwoywyać i definiować "geny", czyli zbiór wybranych kanałów
        //bliźniaczo do genów powinniśmy mieć tablicę wyników mieszania, żeby określać na jej podstawie sprawdzić ilość kolizji
        //  czyli sumę np. sumę wyników mieszania po indeksach kanałów z sygnałem właściwym 
        public Chromosome(int NumberOfGenes)
        {
            throw new NotImplementedException("Chromosome");
        }

        public void Mutate()
        {
            throw new NotImplementedException("Chromosome.Mutate");
        }

        private void CalculateCollisions()
        {
            throw new NotImplementedException("Chromosome.CalculateCollisions");
        }

        private void GenerateAllPairs()
        {
            throw new NotImplementedException("Chromosome.GenerateAllPairs");
        }
        private void GenerateAllCollisions()
        {
            throw new NotImplementedException("Chromosome.GenerateAllCollisions");
        }
        public string PrintResult()
        {
            throw new NotImplementedException("Chromosome.PrintResult");
        }
    }
}
