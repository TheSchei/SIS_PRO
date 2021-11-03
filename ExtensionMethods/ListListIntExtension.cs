using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_PRO.ExtensionMethods
{
    public static class ListListIntExtension
    {
        // Metoda do sprawdzania czy dana lista znajduje się na liście list (czy dana kombinacja już została wybrana)
        public static Boolean ContainsList(this List<List<int>> baseList, List<int> searchedList)
        {
            searchedList.Sort();

            foreach (var list in baseList)
            {
                list.Sort();

                int sameNumbers = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == searchedList[i])
                        sameNumbers++;
                }

                if (sameNumbers == list.Count)
                    return true;
            }
            return false;
        }
    }
}
