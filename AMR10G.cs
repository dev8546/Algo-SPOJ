using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class AMR10G
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
                int N = int.Parse(str[0]);
                int K = int.Parse(str[1]);
                int[] h = new int[N];
                str = Console.ReadLine().Split();
                for (int i = 0; i < N; i++)
                {
                    h[i] = int.Parse(str[i]);
                }
                Array.Sort(h);
                int minDiff = Int32.MaxValue;
                for (int i = 0; i <= (N - K); i++)
                {
                    int diff = h[K + i - 1] - h[i];
                    if (diff < minDiff)
                        minDiff = diff;
                }
                Console.WriteLine(minDiff);
                t--;
            }
        }
    }
}

