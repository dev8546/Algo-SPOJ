using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoSolution
{
        class APS
        {
            static void Main()
            {
                int t = int.Parse(Console.ReadLine());
                long[] sum = new long[10000001];
                sum[0] = sum[1] = 0;
                bool[] pList = PrimeList();
                for (int i = 2; i < 10000001; i++)
                {
                    if (pList[i] == false)
                    {
                        sum[i] = sum[i - 1] + i;
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            sum[i] = sum[i - 1] + 2;
                        }
                        else
                        {
                            for (int j = 3; j < 10000001; j += 2)
                            {
                                if (pList[j] == false)
                                {
                                    if (i % j == 0)
                                    {
                                        sum[i] = sum[i - 1] + j;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                while (t > 0)
                {
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine(sum[n]);
                    t--;
                }
            }

            static bool[] PrimeList()
            {
                bool[] primeList = new bool[10000001];
                for (int i = 2; i < 10000001; i++)
                {
                    if (primeList[i] == false)
                    {
                        int counter = 2;
                        while (i * counter < 10000001)
                        {
                            primeList[i * counter] = true;
                            counter++;
                        }
                    }
                }
                return primeList;
            }
        }
}
