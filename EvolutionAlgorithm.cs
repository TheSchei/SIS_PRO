﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_PRO
{
    class EvolutionAlgorithm
    {
        private Chromosome BestResult;
        private int NumberOfChanels;
        public EvolutionAlgorithm(int NumberOfChanels)
        {
            this.NumberOfChanels = NumberOfChanels;
        }
        public void FindBestSolution()
        {
            int Size = NumberOfChanels * NumberOfChanels;
            if (TryToFindSolution(Size))//można ewentualnie jakoś zoptymalizaować, np. sprawdzając jak szybko znaleziono rezultat
            {//trafiono od razu, więc zmniejszamy rozmiar po jednym tak długo jak siębędzie udawać
                while (!TryToFindSolution(--Size));
                Size++;
            }
            else//nie trafiono, więc zwiększamy aż się nie uda
                while (TryToFindSolution(++Size));

        }
        private bool TryToFindSolution(int size)//true - znaleziono (wtedy jeszcze ustawia BestResult)
        {
            throw new NotImplementedException("EvolutionAlgorithm.TryToFindSolution");
        }
        public void PrintResult()
        {
            throw new NotImplementedException("EvolutionAlgorithm.PrintResult");
        }
    }
}
