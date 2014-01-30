﻿using System;

namespace AlgoSolution
{
    public class ANARC05B
    {

        public static void Main()
        {
            Run();
        }
        static void Run()
        {
            while (true)
            {
                string readOne = Console.ReadLine().Trim();
                string[] str1 = readOne.Split();
                int len1 = int.Parse(str1[0]);
                if (len1 == 0)
                    break;
                int[] set1 = new int[len1];
                int counter = 1;
                for (int i = 0; i < len1; i++)
                {
                    if (!string.IsNullOrEmpty(str1[counter].Trim()))
                    {
                        set1[i] = int.Parse(str1[counter].Trim());
                    }
                    else
                    {
                        i--;
                    }
                    counter++;
                }
                string readTwo = Console.ReadLine().Trim();
                string[] str2 = readTwo.Split();
                int len2 = int.Parse(str2[0]);
                int[] set2 = new int[len2];
                counter = 1;
                for (int i = 0; i < len2; i++)
                {
                    if (!string.IsNullOrEmpty(str2[counter].Trim()))
                    {
                        set2[i] = int.Parse(str2[counter].Trim());
                    }
                    else
                    {
                        i--;
                    }
                    counter++;
                }
                int lastMatchIndex = -2;
                int lastOptimizeVal = 0;
                int sum1 = 0;
                for (int i = 0; i < len1; i++)
                {
                    int p = Array.BinarySearch(set2, lastMatchIndex == -2 ? 0 : lastMatchIndex, lastMatchIndex == -2 ? len2 : len2 - lastMatchIndex, set1[i]);
                    sum1 += set1[i];
                    if (p >= 0)
                    {
                        int sum = 0;
                        if (lastMatchIndex == -2)
                        {
                            lastMatchIndex = -1;
                        }
                        else
                        {
                            sum += lastOptimizeVal;
                        }

                        for (int j = lastMatchIndex + 1; j <= p; j++)
                        {
                            sum += set2[j];
                        }
                        lastMatchIndex = p;
                        sum1 = Math.Max(sum, sum1);
                        lastOptimizeVal = sum1;
                    }
                }
                int finalSum = 0;
                if (lastMatchIndex == -2)
                {
                    lastMatchIndex = -1;
                }
                else
                {
                    finalSum = lastOptimizeVal;
                }
                for (int j = lastMatchIndex + 1; j < set2.Length; j++)
                {
                    finalSum += set2[j];
                }
                Console.WriteLine(Math.Max(finalSum, sum1));

            }

        }
    }

}

