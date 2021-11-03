using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_PRO.ExtensionMethods
{
    public static class ListIntExtensions
    {
        public static List<int> DeepCopy(this List<int> ints)
        {
            var temp = new List<int>();

            for (int i = 0; i < ints.Count; i++)
            {
                int a = ints[i];
                temp.Add(a);
            }
            return temp;
        }
    }
}
