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
        private int NumberOfCollisions;
        private Random rnd = new Random();

        public Chromosome(int NumberOfGenes)
        {
            Channels = new List<int>();
            GenerateBaseSolution(NumberOfGenes);
            GenerateAllPairs(Channels);
            //throw new NotImplementedException("Chromosome");
        }

        public void Mutate()
        {
            throw new NotImplementedException("Chromosome.Mutate");
        }

        private void CalculateCollisions(List<List<int>> combinations, List<int> channels)  // wyliczanie produktów mieszania i kolizji z sygnałami wejściowymi
        {
            //var harmonics = new List<int>();    // lista przechowująca wszystkie produkty mieszania
            Dictionary<int, int> collisionsForEveryChannel =
                new Dictionary<int, int>();

            /*foreach (var combination in combinations)
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
            }*/
            //throw new NotImplementedException("Chromosome.CalculateCollisions");

            foreach (int channel in channels)
                collisionsForEveryChannel.Add(channel, 0);

            foreach (var combination in combinations)
            {
                int A = combination[0];
                int B = combination[1];
                int C = combination[2];

                TryToAddCollision(A + A - B, collisionsForEveryChannel);
                TryToAddCollision(A + A - C, collisionsForEveryChannel);
                TryToAddCollision(A + B - C, collisionsForEveryChannel);
                TryToAddCollision(A + C - B, collisionsForEveryChannel);
                TryToAddCollision(B + B - A, collisionsForEveryChannel);
                TryToAddCollision(B + B - C, collisionsForEveryChannel);
                TryToAddCollision(B + C - A, collisionsForEveryChannel);
                TryToAddCollision(C + C - A, collisionsForEveryChannel);
                TryToAddCollision(C + C - B, collisionsForEveryChannel);
            }
            NumberOfCollisions = MaxValue(collisionsForEveryChannel);
        }

        private void TryToAddCollision(int f, Dictionary<int, int> collisionsForEveryChannel)
        {
            if (collisionsForEveryChannel.ContainsKey(f)) collisionsForEveryChannel[f]++;
        }
        private int MaxValue(Dictionary<int, int> collisionsForEveryChannel)
        {
            int output = 0;
            foreach (int f in Channels)
                if (collisionsForEveryChannel[f] > output) output = collisionsForEveryChannel[f];
            return output;

        }

        private void GenerateAllPairs(List<int> channels)   // Generowanie wszystkich kombinacji częstotliwości produktów mieszania
        {
            var pickedCombinations = new List<List<int>>();

            //int allPossibleCombinations = MathOperations.NewtonSymbol(channels.Count, 3);

            int Length = channels.Count;

            for (int i = 0; i < Length - 2; i++)
                for (int j = i + 1; j < Length - 1; j++)
                    for (int k = j + 1; k < Length; k++)
                        pickedCombinations.Add(new List<int>() { channels[i], channels[j], channels[k] });

            /*
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
            */
            CalculateCollisions(pickedCombinations, channels);
        }

        private void GenerateBaseSolution(int numberOfGenes)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                while (true)
                {
                    int newChannel = rnd.Next(numberOfGenes);//mnożnik wybierany jest wyżej w Genome
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
