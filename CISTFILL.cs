﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChefHacks
{
    struct CISTERN
    {
        public int W;
        public int D;
        public int H;
        public int BASE;
    }
    class CISTFILL
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
                int totalContainers = int.Parse(Console.ReadLine());
                CISTERN[] c = new CISTERN[totalContainers];
                int totalV = 0;
                double maxK = int.MinValue;
                for (int i = 0; i < totalContainers; i++)
                {
                    string[] s = Console.ReadLine().Split();
                    c[i].BASE = int.Parse(s[0]);
                    c[i].H = int.Parse(s[1]);
                    c[i].W = int.Parse(s[2]);
                    c[i].D = int.Parse(s[3]);
                    totalV += c[i].D * c[i].H * c[i].W;
                    if (c[i].BASE + c[i].H > maxK)
                        maxK = c[i].BASE + c[i].H;
                }
                int V = int.Parse(Console.ReadLine());
                if (totalV < V)
                    Console.WriteLine("OVERFLOW");
                else
                {
                    double minK = 0;
                    while (Math.Round(minK, 4) < Math.Round(maxK, 4))
                    {
                        double midPoint = minK + (maxK - minK) / 2.0;
                        double possibleVolume = 0.0;
                        for (int i = 0; i < totalContainers; i++)
                        {
                            if (c[i].BASE < midPoint)
                            {
                                if (c[i].H + c[i].BASE > midPoint)
                                {
                                    possibleVolume += c[i].D * c[i].W * (midPoint - c[i].BASE);
                                }
                                else
                                {
                                    possibleVolume += c[i].H * c[i].W * c[i].D;
                                }
                            }
                        }
                        if (possibleVolume < V)
                        {
                            minK = midPoint;
                        }
                        else
                        {
                            maxK = midPoint;
                        }
                    }
                    Console.WriteLine(String.Format("{0:0.00}", minK));
                }
                t--;
            }
            Console.ReadLine();
        }

    }
}

