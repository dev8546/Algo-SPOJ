using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    class DCOWS
    {
        static void Main()
        {
            Run();
            Console.ReadLine();
        }
        static void Run()
        {
            string[] str = Console.ReadLine().Split();
            int totalBulls = int.Parse(str[0]);
            int totalCows = int.Parse(str[1]);
            long[] bulls = new long[totalBulls];
            long[] cows = new long[totalCows];
            for (int i = 0; i < totalBulls; i++)
                bulls[i] = long.Parse(Console.ReadLine());
            for (int i = 0; i < totalCows; i++)
                cows[i] = long.Parse(Console.ReadLine());
            Array.Sort(bulls);
            Array.Sort(cows);
            long diff = totalCows - totalBulls + 1;
            long[] cost = new long[diff];
            long minVal = long.MaxValue;
            for (long i = cows.Length - 1, j = diff - 1; i >= cows.Length - diff; i--, j--)
            {
                long hdiff = Math.Abs(bulls[bulls.Length - 1] - cows[i]);
                if (hdiff < minVal)
                    minVal = hdiff;
                cost[j] = minVal;
            }
            for (int i = bulls.Length - 2; i >= 0; i--)
            {
                long[] tmp = new long[diff];
                long bullHeight = bulls[i];
                minVal = long.MaxValue;
                for (long j = diff - 1; j >= 0; j--)
                {
                    long cowHeight = cows[i + j];
                    long hdiff = Math.Abs(cowHeight - bullHeight) + cost[j];
                    if (hdiff < minVal)
                        minVal = hdiff;
                    tmp[j] = minVal;
                }
                cost = tmp;
            }
            Console.WriteLine(minVal);
        }

    }


}

