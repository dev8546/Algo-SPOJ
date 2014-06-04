﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    class C1LJUTNJ
    {
        static void Main(string[] args)
        {
            Run();
        }
        static void Run()
        {
            string[] strLineOne = Console.ReadLine().Split();
            long M = long.Parse(strLineOne[0]);
            long N = long.Parse(strLineOne[1]);
            long[] num = new long[N];
            long maxVal = -1;
            for (int i = 0; i < N; i++)
            {
                num[i] = long.Parse(Console.ReadLine());
                if (num[i] > maxVal)
                    maxVal = num[i];
            }
            long minVal = 0;
            long totalChocoUsed = 0;
            while (minVal < maxVal)
            {
                long mid = minVal + (maxVal - minVal) / 2;
                totalChocoUsed = 0;
                for (int i = 0; i < N; i++)
                {
                    if (num[i] >= mid)
                    {
                        totalChocoUsed += num[i] - mid;
                    }
                }
                if (totalChocoUsed > M)
                {
                    minVal = mid + 1;
                }
                else
                {
                    maxVal = mid;
                }
            }
            long finalEqal = minVal;
            long remainingChoco = M;
            long angerVal = 0;
            for (int i = 0; i < N; i++)
            {
                if (num[i] < finalEqal)
                {
                    angerVal += num[i] * num[i];
                }
                else
                {

                    {
                        angerVal += finalEqal * finalEqal;
                        remainingChoco -= num[i] - finalEqal;
                    }
                }
            }
            Console.WriteLine(angerVal - (finalEqal * finalEqal - (finalEqal - 1) * (finalEqal - 1)) * remainingChoco);
            Console.ReadLine();
        }
    }
}

