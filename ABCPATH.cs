using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    class ABCPATH
    {
        static int[,] plot;
        static void Main()
        {
            Run();
            Console.ReadLine();
        }
        static Dictionary<string, int> dp;
        static void Run()
        {
            int counter = 0;
            while (true)
            {
                counter++;
                string[] str = Console.ReadLine().Split();
                int H = int.Parse(str[0]);
                int W = int.Parse(str[1]);
                if (H == 0 && W == 0)
                    break;
                plot = new int[H, W];
                dp = new Dictionary<string, int>();
                for (int i = 0; i < H; i++)
                {
                    string entry = Console.ReadLine();
                    for (int j = 0; j < W; j++)
                    {
                        plot[i, j] = (int)entry[j]; // A : 65 , Z: 90
                    }
                }
                int overallBest = 0;
                for (int i = 0; i < H; i++)
                {
                    for (int j = 0; j < W; j++)
                    {
                        if (plot[i, j] == 65)
                        {
                            int mybest = DFS(i, j, H, W, 65);
                            if (mybest > overallBest)
                                overallBest = mybest;
                        }
                    }
                }
                Console.WriteLine(string.Format("Case {0}: {1}", counter, overallBest));
            }
        }

        static int DFS(int i, int j, int H, int W, int currentNumber)
        {
            plot[i, j] = -1;//Visited
            string key = string.Format("{0}-{1}", i, j);
            if (dp.ContainsKey(key))
                return dp[key];
            int localBest = 1;
            if (j - 1 >= 0)
            {
                //side one
                if (plot[i, j - 1] == currentNumber + 1)
                {
                    int max = DFS(i, j - 1, H, W, currentNumber + 1) + 1;
                    if (max > localBest)
                        localBest = max;
                }
                if (i - 1 >= 0) // diagonal
                {
                    if (plot[i - 1, j - 1] == currentNumber + 1)
                    {
                        int max = DFS(i - 1, j - 1, H, W, currentNumber + 1) + 1;
                        if (max > localBest)
                            localBest = max;
                    }
                }
                if (i + 1 < H)
                {
                    if (plot[i + 1, j - 1] == currentNumber + 1)
                    {
                        int max = DFS(i + 1, j - 1, H, W, currentNumber + 1) + 1;
                        if (max > localBest)
                            localBest = max;
                    }
                }
            }
            if (j + 1 < W)
            {
                //side one
                if (plot[i, j + 1] == currentNumber + 1)
                {
                    int max = DFS(i, j + 1, H, W, currentNumber + 1) + 1;
                    if (max > localBest)
                        localBest = max;
                }
                if (i - 1 >= 0) // diagonal
                {
                    if (plot[i - 1, j + 1] == currentNumber + 1)
                    {
                        int max = DFS(i - 1, j + 1, H, W, currentNumber + 1) + 1;
                        if (max > localBest)
                            localBest = max;
                    }
                }
                if (i + 1 < H)
                {
                    if (plot[i + 1, j + 1] == currentNumber + 1)
                    {
                        int max = DFS(i + 1, j + 1, H, W, currentNumber + 1) + 1;
                        if (max > localBest)
                            localBest = max;
                    }
                }
            }
            if (i - 1 >= 0)
            {
                if (plot[i - 1, j] == currentNumber + 1)
                {
                    int max = DFS(i - 1, j, H, W, currentNumber + 1) + 1;
                    if (max > localBest)
                        localBest = max;
                }
            }
            if (i + 1 < H)
            {
                if (plot[i + 1, j] == currentNumber + 1)
                {
                    int max = DFS(i + 1, j, H, W, currentNumber + 1) + 1;
                    if (max > localBest)
                        localBest = max;
                }
            }
            dp.Add(key, localBest);
            return localBest;
        }
    }
}

