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
        private int NumberOfGenes;
        private int Width;
        private Random rnd;

        public Chromosome(int NumberOfGenes, int Width)
        {
            Channels = new List<int>();
            rnd = new Random();
            this.NumberOfGenes = NumberOfGenes;
            this.Width = Width;
            GenerateBaseSolution();
            CalculateCollisions();
        }
        private Chromosome(int NumberOfGenes, int NumberOfCollisions, List<int> Channels, int Width)
        {
            this.Channels = new List<int>();
            rnd = new Random();
            this.NumberOfGenes = NumberOfGenes;
            this.NumberOfCollisions = NumberOfCollisions;
            this.Width = Width;
            foreach (int channel in Channels)
                this.Channels.Add(channel);
        }
        public Chromosome DeepCopy()
        {
            return new Chromosome(NumberOfGenes, NumberOfCollisions, Channels, Width);
        }

        public void Mutate()
        {
            int FromGene = GetGeneIndex();
            TransitGene(FromGene);
            CalculateCollisions();
        }
        private int GetGeneIndex()
        {
            return rnd.Next(Channels.Count);
        }
        private void TransitGene(int FromGene)
        {
            int ToGene = rnd.Next(Width);
            while(Channels.Contains(ToGene))
                ToGene = rnd.Next(NumberOfGenes);
            Channels[FromGene] = ToGene;
            Channels.Sort();
        }

        private void SumCollisions(List<List<int>> combinations, List<int> channels)  // wyliczanie produktów mieszania i kolizji z sygnałami wejściowymi
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

        private void CalculateCollisions()   // Generowanie wszystkich kombinacji częstotliwości produktów mieszania
        {
            var pickedCombinations = new List<List<int>>();

            //int allPossibleCombinations = MathOperations.NewtonSymbol(channels.Count, 3);

            int Length = Channels.Count;

            for (int i = 0; i < Length - 2; i++)
                for (int j = i + 1; j < Length - 1; j++)
                    for (int k = j + 1; k < Length; k++)
                        pickedCombinations.Add(new List<int>() { Channels[i], Channels[j], Channels[k] });

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
            SumCollisions(pickedCombinations, Channels);
        }

        private void GenerateBaseSolution()
        {
            for (int i = 0; i < NumberOfGenes; i++)
            {
                while (true)
                {
                    int newChannel = rnd.Next(Width);//mnożnik wybierany jest wyżej w Genome
                    if (!Channels.Contains(newChannel))
                    {
                        Channels.Add(newChannel);
                        break;
                    }
                }
            }
            Channels.Sort();
        }

        public int getValue()
        {
            return NumberOfCollisions;
        }

        public string PrintResult()
        {
            string output = "";
            output += "Liczba kolizji to: " + NumberOfCollisions.ToString() + Environment.NewLine;
            output += "Szerokość kanału to: " + Width.ToString() + Environment.NewLine;
            output += "Zajęte kanały to: " + Environment.NewLine;
            output += "Zajęte kanały to: " + PrintChanels() + Environment.NewLine;
            output += Environment.NewLine;
            throw new NotImplementedException("Chromosome.PrintResult");
        }
        private string PrintChanels()
        {
            string output = "";
            foreach (int channel in Channels)
                output += channel.ToString() + " ";
            return output;
        }
    }
}
