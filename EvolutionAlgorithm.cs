using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_PRO
{
    class EvolutionAlgorithm
    {
        private Chromosome BestResult;
        private int NumberOfChanels;
        private int ChannelSize;
        public EvolutionAlgorithm(int NumberOfChanels)
        {
            this.NumberOfChanels = NumberOfChanels;
        }
        public void FindBestSolution()
        {
            if (NumberOfChanels >= 3)
            {
                int Size = NumberOfChanels * NumberOfChanels;
                if (TryToFindSolution(Size))//można ewentualnie jakoś zoptymalizaować, np. sprawdzając jak szybko znaleziono rezultat
                {//trafiono od razu, więc zmniejszamy rozmiar po jednym tak długo jak siębędzie udawać
                    Size--;
                    while (TryToFindSolution(Size))
                    {
                        Size = ChannelSize;
                        Size--;
                    }
                }
                else//nie trafiono, więc zwiększamy aż się nie uda
                    while (!TryToFindSolution(++Size)) ;
            }
        }
        private bool TryToFindSolution(int size)//true - znaleziono (wtedy jeszcze ustawia BestResult)
        {
            if (size <= 3)  // Wtedy program się zapętla z jakiegoś powodu
                return false;
            Genome Solver = new Genome(NumberOfChanels, size);
            Chromosome NewBestResult = Solver.Run();
            if(!(NewBestResult is null))
            {
                NewBestResult.FormatChannels();
                BestResult = NewBestResult;
                ChannelSize = NewBestResult.getChannelWidth();
                return true;
            }
            return false;
        }
        public string PrintResult()
        {
            if (NumberOfChanels == 2)       // hardcode jak są 2 kanały - zrobiłem tak, bo nie chciało mi się bawić z konstruktorami chromosomów
            {
                string output = "";
                output += "Liczba kolizji to: 0" + Environment.NewLine;
                output += "Szerokość pasma to: 1" + Environment.NewLine;
                output += "Zajęte kanały to: " + Environment.NewLine;
                output += $"[0,1]" + Environment.NewLine;
                output += Environment.NewLine;
                return output;
            }
            return BestResult.PrintResult();
        }
    }
}
