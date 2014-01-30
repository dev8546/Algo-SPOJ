﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class COINS
    {
        public static void Main()
        {
            Run();
        }
        static Dictionary<int, long> cal = new Dictionary<int, long>();
        static void Run()
        {
            while (true)
            {
                string str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                    break;
                int N = int.Parse(str);
                Console.WriteLine(Cal(N));
            }
            Console.ReadLine();
        }

        static long Cal(int N)
        {
            if (cal.ContainsKey(N))
                return cal[N];
            if (N == 0)
                return 0;
            if (N == 1)
                return 1;
            cal.Add(N, Math.Max(N, Cal(N / 2) + Cal(N / 3) + Cal(N / 4)));
            return cal[N];
        }
    }
}

