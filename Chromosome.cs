using System;
using System.Collections.Generic;

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
            this.Width = Width + 1;
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
            double probability = rnd.NextDouble();
            if (probability >= 0.75)
            {
                MutateGene();
                MutateGene();
                MutateGene();
            }
            else if (probability >= 0.5)
            {
                MutateGene();
                MutateGene();
            }
            else
                MutateGene();

            CalculateCollisions();
        }
        private void MutateGene()
        {
            int FromGene = GetGeneIndex();
            TransitGene(FromGene);
        }
        private int GetGeneIndex()
        {
            return rnd.Next(Channels.Count);
        }
        private void TransitGene(int FromGene)
        {
            int ToGene = rnd.Next(Width);
            while (Channels.Contains(ToGene))
                ToGene = rnd.Next(Width);
            Channels[FromGene] = ToGene;
            Channels.Sort();
        }

        private void SumCollisions(List<List<int>> combinations, List<int> channels)  // wyliczanie produktów mieszania i kolizji z sygnałami wejściowymi
        {
            //var harmonics = new List<int>();    // lista przechowująca wszystkie produkty mieszania
            Dictionary<int, int> collisionsForEveryChannel =
                new Dictionary<int, int>();

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

            int Length = Channels.Count;

            for (int i = 0; i < Length - 2; i++)
                for (int j = i + 1; j < Length - 1; j++)
                    for (int k = j + 1; k < Length; k++)
                        pickedCombinations.Add(new List<int>() { Channels[i], Channels[j], Channels[k] });

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

        public int getChannelWidth()
        {
            return Channels[Channels.Count - 1];
        }

        public string PrintResult()
        {
            string output = "";
            output += "Liczba kolizji to: " + NumberOfCollisions.ToString() + Environment.NewLine;
            output += "Szerokość pasma to: " + getChannelWidth().ToString() + Environment.NewLine;
            output += "Zajęte kanały to: " + Environment.NewLine;
            output += $"[{PrintChanels()}]" + Environment.NewLine;
            output += Environment.NewLine;
            return output;
        }
        private string PrintChanels()
        {
            string output = "";
            foreach (int channel in Channels)
                output += channel.ToString() + " ";
            return output;
        }

        // Czasami znajduje takie wyniki, gdzie kanały to np. [7,14,...] zamiast [0,7,...]
        public void FormatChannels()
        {
            if (Channels[0] != 0)
            {
                int difference = Channels[0];
                for (int i = 0; i < Channels.Count; i++)
                    Channels[i] -= difference;
            }
        }
    }
}
