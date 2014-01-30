using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class AGGRCOW
    {
        static void Main()
        {
            Run();
        }
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string[] str = Console.ReadLine().Split();
                int TotalStalls = int.Parse(str[0]);
                int totalCows = int.Parse(str[1]);
                int[] positions = new int[TotalStalls];
                for (int i = 0; i < TotalStalls; i++)
                    positions[i] = int.Parse(Console.ReadLine());
                Array.Sort(positions);
                int min = 1;
                int max = 1000000000;
                while (min < max)
                {
                    int midPosition = min + (max - min + 1) / 2;
                    int maxCow = 1;
                    long cowPosition = positions[0] + midPosition;
                    for (int i = 1; i < TotalStalls; i++)
                    {
                        if (positions[i] >= cowPosition)
                        {
                            maxCow++;
                            cowPosition = positions[i] + midPosition;
                        }
                    }
                    if (maxCow < totalCows)
                    {
                        max = midPosition - 1;
                    }
                    else
                    {
                        min = midPosition;
                    }
                }
                Console.WriteLine(min);
                t--;
            }
        }
    }
}

