﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class ANARC05H
    {
        public static void Main()
        {
            Run();
        }
        static int[,] cache;
        static void Run()
        {
            int counter = 1;
            while (true)
            {
                string str = Console.ReadLine();
                if (string.Compare(str, "bye", true) == 0)
                    break;
                cache = new int[str.Length + 1, 250];
                Console.WriteLine(string.Format("{0}. {1}", counter, DP(str, 0, str.Length - 1, 0)));
                counter++;
            }
            Console.ReadLine();

        }
        static int DP(string str, int startIndex, int endIndex, int prevSum)
        {
            if (startIndex > endIndex)
                return 1;
            if (cache[startIndex, prevSum] > 0)
                return cache[startIndex, prevSum];
            int totalCount = 0;
            int sum = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                sum += int.Parse(str[i].ToString());
                if (sum >= prevSum)
                {
                    totalCount += DP(str, i + 1, endIndex, sum);

                }
            }
            cache[startIndex, prevSum] = totalCount;
            return totalCount;
        }
    }
}

