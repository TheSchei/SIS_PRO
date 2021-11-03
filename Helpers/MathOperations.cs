using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_PRO.Helpers
{
    public static class MathOperations
    {
        public static int NewtonSymbol(int n, int k)
        {
            return Factorial(n) / Factorial(k) * Factorial(n - k);
        }
        public static int Factorial(int n)
        {
            if (n > 1)
            {
                return Factorial(n - 1) * n;
            }
            else
            {
                return 1;
            }
        }
    }
}
