﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class FACEFRND
    {
        public static void Main()
        {
            Run();
        }
        static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int totalFF = 0;
            string[] input = new string[n];
            Dictionary<int, bool> f = new Dictionary<int, bool>();
            Dictionary<int, bool> ff = new Dictionary<int, bool>();
            for (int i = 0; i < n; i++)
            {
                input[i] = Console.ReadLine();
                f.Add(int.Parse(input[i].Split()[0]), true);
            }
            for (int i = 0; i < n; i++)
            {
                string[] str = input[i].Split();
                int totalN = int.Parse(str[1]);
                for (int j = 0; j < totalN; j++)
                {
                    int id = int.Parse(str[j + 2]);
                    if (!f.ContainsKey(id) && !ff.ContainsKey(id))
                    {
                        totalFF++;
                        ff.Add(id, true);
                    }
                }
            }
            Console.WriteLine(totalFF);
        }
    }
}

