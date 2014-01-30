﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class CANDY3
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
                Console.ReadLine();
                long N = long.Parse(Console.ReadLine());
                long sum = 0;
                for (int i = 0; i < N; i++)
                {
                    sum = (sum + long.Parse(Console.ReadLine())) % N;
                }
                if (sum % N == 0)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
                t--;
            }
        }
    }
}

