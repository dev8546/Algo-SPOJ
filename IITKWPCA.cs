﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    struct MyText
    {
    }
    class IITKWPCA
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
                string[] str = Console.ReadLine().Split();
                Dictionary<string, int> inData = new Dictionary<string, int>();
                int totalCount = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    if (!string.IsNullOrEmpty(str[i]))
                    {
                        if (!inData.ContainsKey(str[i]))
                        {
                            totalCount++;
                            inData.Add(str[i], 1);
                        }


                    }
                }
                Console.WriteLine(totalCount);
                t--;
            }
        }
    }
}

