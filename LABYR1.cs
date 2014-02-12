using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{

    class BFS
    {
        static void Main()
        {
            Run();
            Console.ReadLine();
        }

        static int DFS(int i, int j, int R, int C)
        {
            plot[i, j] = 0;
            int localBest = 0;
            int secondBest = 0;
            if (j - 1 >= 0)
            {
                if (plot[i, j - 1] == 1)
                {

                    int maxlen = DFS(i, j - 1, R, C) + 1;
                    if (maxlen >= localBest)
                    {
                        secondBest = localBest;
                        localBest = maxlen;
                    }
                    else if (maxlen > secondBest)
                    {
                        secondBest = maxlen;
                    }

                }
            }
            if (j + 1 < C)
            {
                if (plot[i, j + 1] == 1)
                {
                    int maxlen = DFS(i, j + 1, R, C) + 1;
                    if (maxlen >= localBest)
                    {
                        secondBest = localBest;
                        localBest = maxlen;
                    }
                    else if (maxlen > secondBest)
                    {
                        secondBest = maxlen;
                    }
                }
            }
            if (i - 1 >= 0)
            {
                if (plot[i - 1, j] == 1)
                {
                    int maxlen = DFS(i - 1, j, R, C) + 1;
                    if (maxlen >= localBest)
                    {
                        secondBest = localBest;
                        localBest = maxlen;
                    }
                    else if (maxlen > secondBest)
                    {
                        secondBest = maxlen;
                    }
                }
            }
            if (i + 1 < R)
            {
                if (plot[i + 1, j] == 1)
                {
                    int maxlen = DFS(i + 1, j, R, C) + 1;
                    if (maxlen >= localBest)
                    {
                        secondBest = localBest;
                        localBest = maxlen;
                    }
                    else if (maxlen > secondBest)
                    {
                        secondBest = maxlen;
                    }
                }
            }
            bestSolution = bestSolution > (secondBest + localBest) ? bestSolution : (secondBest + localBest);
            return localBest;
        }
        static int[,] plot;
        static int bestSolution;
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string[] str = Console.ReadLine().Split();
                int R = int.Parse(str[1]);
                int C = int.Parse(str[0]);
                plot = new int[R, C];
                bestSolution = 0;
                for (int i = 0; i < R; i++)
                {
                    string entry = Console.ReadLine();
                    for (int j = 0; j < C; j++)
                    {
                        plot[i, j] = entry[j] == '#' ? 0 : 1;
                    }
                }
                for (int i = 0; i < R; i++)
                {
                    for (int j = 0; j < C; j++)
                    {

                        if (plot[i, j] == 1)
                        {
                            DFS(i, j, R, C);
                        }

                    }
                }

                Console.WriteLine(string.Format("Maximum rope length is {0}.", bestSolution));
                t--;
            }
        }
    }
}

