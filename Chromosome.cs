using SIS_PRO.ExtensionMethods;
using SIS_PRO.Helpers;
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
        private List<int> Channels;
        private List<int> ProductChannels;
        private int NumberOfCollisions;
        private Random rnd = new Random();

        public Chromosome(int NumberOfGenes)
        {
            Channels = new List<int>();
            NumberOfCollisions = 0;
            ProductChannels = new List<int>();

            GenerateAllPairs(NumberOfGenes);
            GenerateAllCollisions(Channels);
            //throw new NotImplementedException("Chromosome");
        }

        public void Mutate()
        {
            throw new NotImplementedException("Chromosome.Mutate");
        }

        private void CalculateCollisions(List<List<int>> combinations, List<int> channels)  // wyliczanie produktów mieszania i kolizji z sygnałami wejściowymi
        {
            var harmonics = new List<int>();    // lista przechowująca wszystkie produkty mieszania
            Dictionary<int, int> collisionsForEveryChannel =
                new Dictionary<int, int>();

            foreach (var combination in combinations)
            {
                int fi = combination[0];
                int fj = combination[1];
                int fk = combination[2];

                harmonics.Add(fi + fj - fk);
                harmonics.Add(fi - fj + fk);
                harmonics.Add(-fi + fj + fk);
                harmonics.Add(fi + fj + fk);
            }

            foreach (int channel in channels)
            {
                int numberOfCollisions = 0;

                foreach (int harmonic in harmonics)
                {
                    if (harmonic == channel)
                        numberOfCollisions++;
                }
                collisionsForEveryChannel.Add(channel, numberOfCollisions);     // słownik, którego kluczem jest numer kanału wejściowego, a wartością ilość kolizji.
            }
            //throw new NotImplementedException("Chromosome.CalculateCollisions");
        }

        private void GenerateAllCollisions(List<int> channels)   // Generowanie wszystkich kombinacji częstotliwości produktów mieszania
        {
            var pickedCombinations = new List<List<int>>();

            int allPossibleCombinations = MathOperations.NewtonSymbol(channels.Count, 3);

            for (int i = 0; i < allPossibleCombinations; i++)
            {
                while (true)
                {
                    var tempList = channels.DeepCopy();
                    int fi = tempList[rnd.Next(tempList.Count)];
                    tempList.Remove(fi);
                    int fj = tempList[rnd.Next(tempList.Count)];
                    tempList.Remove(fj);
                    int fk = tempList[rnd.Next(tempList.Count)];

                    var combination = new List<int>() { fi, fj, fk };
                    combination.Sort();

                    if (!pickedCombinations.ContainsList(combination))
                    {
                        pickedCombinations.Add(combination);
                        break;
                    }
                }
            }

            CalculateCollisions(pickedCombinations, channels);
        }

        private void GenerateAllPairs(int numberOfGenes)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                while (true)
                {
                    int newChannel = rnd.Next(2 * numberOfGenes);
                    if (!Channels.Contains(newChannel))
                    {
                        Channels.Add(newChannel);
                        break;
                    }
                }
            }
            Channels.Sort();
        }

        public string PrintResult()
        {
            throw new NotImplementedException("Chromosome.PrintResult");
        }
    }
}
