﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    struct RING : IComparable
    {
        public int r1;
        public int r2;
        public int Id;
        public int CompareTo(Object obj)
        {
            RING r = (RING)obj;
            if (this.r1 != r.r1)
            {
                return this.r1.CompareTo(r.r1);
            }
            return this.r2.CompareTo(r.r2);
        }
    }
    class BWIDOW
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
                RING[] rings = new RING[n];
                for (int i = 0; i < n; i++)
                {
                    string[] strCircle = Console.ReadLine().Split();
                    int innerRadius = int.Parse(strCircle[0]);
                    int outerRadius = int.Parse(strCircle[1]);
                    rings[i].r1 = innerRadius;
                    rings[i].r2 = outerRadius;
                    rings[i].Id = i + 1;
                }
                Array.Sort(rings);
                bool isPossible = true;
                for (int i = n - 2; i >= 0; i--)
                {
                    if (rings[n - 1].r1 <= rings[i].r2)
                    {
                        isPossible = false;
                        break;
                    }
                }
                if (isPossible)
                {
                    Console.WriteLine(rings[n - 1].Id);
                }
                else
                {
                    Console.WriteLine(-1);
                }
                t--;
            }
        }
    }
}

