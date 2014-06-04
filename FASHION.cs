﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class FASHION
    {
        public static void Main()
        {
            Run();
        }
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                int n = int.Parse(Console.ReadLine());
                int[] M = new int[n];
                int[] W = new int[n];
                string[] strM = Console.ReadLine().Split();
                string[] strW = Console.ReadLine().Split();
                for (int i = 0; i < n; i++)
                {
                    M[i] = int.Parse(strM[i]);
                    W[i] = int.Parse(strW[i]);
                }
                Array.Sort(M);
                Array.Sort(W);
                long totalHotness = 0;
                for (int i = 0; i < n; i++)
                {
                    totalHotness += M[i] * W[i];
                }
                Console.WriteLine(totalHotness);
                t--;
            }
        }
    }
}

