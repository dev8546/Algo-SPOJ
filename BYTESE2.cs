﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChefHacks
{
    struct Log : IComparable
    {
        public int T;
        public bool IsEntry;
        public int CompareTo(Object obj)
        {
            if (((Log)obj).T > this.T)
                return -1;
            return 1;
        }
    }
    class BYTESE2
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
                Log[] timings = new Log[n * 2];
                for (int i = 0; i < n; i++)
                {
                    string[] str = Console.ReadLine().Split();
                    timings[i].T = int.Parse(str[0]);
                    timings[i].IsEntry = true;
                    timings[i + n].T = int.Parse(str[1]);
                    timings[i + n].IsEntry = false;
                }
                Array.Sort(timings);
                int maxNum = Int32.MinValue;
                int currentNum = 0;
                for (int i = 0; i < timings.Length; i++)
                {
                    if (timings[i].IsEntry)
                    {
                        currentNum++;
                        if (currentNum > maxNum)
                            maxNum = currentNum;
                    }
                    else
                    {
                        currentNum--;
                    }
                }
                Console.WriteLine(maxNum);
                t--;
            }
            Console.ReadLine();
        }
    }
}

