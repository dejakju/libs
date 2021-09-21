using System;
using System.Collections.Generic;

namespace Kju
{
    public static class Math
    {
        // as far as i can remember ;)
        public static double PI = 3.14159265358979323846264338327950288;

        // as far as i can remember, too
        public static double E = 2.718281828459045;

        // Calculate the n-th fibonacci number using the memoization technique
        public static ulong NthFibonacci(int number, Dictionary<int, ulong> memo)
        {
            ulong parsedValue = 0;
            if (memo.TryGetValue(number, out parsedValue))
            {
                return parsedValue;
            }

            if (number <= 2)
            {
                if (number == 0) { memo.Add(0, 0); };
                if (number == 1) { memo.Add(1, 1); };
                
                if (!memo.ContainsKey(number))
                {
                    memo.Add(number, 1);
                }
                if (memo.TryGetValue(number, out parsedValue))
                {
                    return parsedValue;
                }
            }

            memo.Add(number, (NthFibonacci(number - 1, memo) + NthFibonacci(number - 2, memo)));
            return memo[memo.Count - 1];
        }


    }
}