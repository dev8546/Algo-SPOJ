using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    struct Histro
    {
        public int Height;
        public int index;
    }
    class METEORAK
    {
        static void Main()
        {
            Run();
            Console.ReadLine();
        }

        static int MaxAreaUnderHistrogram(int[] num, int n)
        {
            Stack<Histro> stack = new Stack<Histro>();
            int maxArea = Int32.MinValue;
            for (int i = 0; i <= n; i++)
            {
                while (stack.Count > 0 && (i == n || stack.Peek().Height > num[i]))
                {
                    Histro toProcess = stack.Pop();
                    int left = -1;
                    if (stack.Count > 0)
                        left = stack.Peek().index;
                    int areaCovered = toProcess.Height * (i - left - 1);
                    if (maxArea < areaCovered)
                        maxArea = areaCovered;
                }

                if (i < n)
                {
                    stack.Push(new Histro() { Height = num[i], index = i });
                }
            }
            return maxArea;
        }

        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string[] strFirst = Console.ReadLine().Split();
                int N = int.Parse(strFirst[0]);
                int M = int.Parse(strFirst[1]);
                //int K = int.Parse(strFirst[2]);
                int[,] landMines = new int[N, M];
                for (int i = 0; i < N; i++)
                {
                    string[] strLandMine = Console.ReadLine().Split();
                    for (int j = 0; j < M; j++)
                    {
                        landMines[i, j] = strLandMine[j] == "F" ? 0 : 1;
                    }
                }
                #region
                int maxArea = Int32.MinValue;
                for (int top = 0; top < 1; top++)
                {
                    int[,] tmp = new int[N, M];
                    for (int bottom = 0; bottom < N; bottom++)
                    {

                        int[] tmparr = new int[M];
                        for (int j = 0; j < M; j++)
                        {
                            if (landMines[bottom, j] == 1)
                            {
                                tmp[bottom, j] = 0;
                                tmparr[j] = 0;
                            }
                            else
                            {
                                if (bottom - 1 >= 0)
                                {
                                    tmp[bottom, j] = tmp[bottom - 1, j] + 1;
                                    tmparr[j] = tmp[bottom - 1, j] + 1; ;
                                }
                                else
                                {
                                    tmp[bottom, j] = 1;
                                    tmparr[j] = 1;
                                }
                            }
                        }

                        int localMaxArea = MaxAreaUnderHistrogram(tmparr, M);
                        if (localMaxArea > maxArea)
                            maxArea = localMaxArea;

                    }
                }
                #endregion
                Console.WriteLine(maxArea * 3);
                Console.ReadLine();
                t--;

            }
        }

    }
}

