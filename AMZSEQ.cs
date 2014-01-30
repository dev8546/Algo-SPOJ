using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class AMZSEQ
    {
        static void Main()
        {
            Run();
        }
        static void Run()
        {
            int N = int.Parse(Console.ReadLine());
            long totalCount = 0;
            if (N == 0)
                Console.WriteLine(1);
            else
            {
                //for (int i = 1; i <= N; i++)
                {
                    totalCount += R(0, 1, N);
                    totalCount += R(1, 1, N);
                    totalCount += R(2, 1, N);
                }
                Console.WriteLine(totalCount);
            }
        }

        static long R(int num, int counter, int N)
        {
            if (counter == N)
                return 1;
            long totalCount = 0;
            if (num == 0)
            {
                totalCount += R(0, counter + 1, N);
                totalCount += R(1, counter + 1, N);
            }
            if (num == 1)
            {
                totalCount += R(2, counter + 1, N);
                totalCount += R(0, counter + 1, N);
                totalCount += R(1, counter + 1, N);
            }
            if (num == 2)
            {
                totalCount += R(1, counter + 1, N);
                totalCount += R(2, counter + 1, N);
            }
            return totalCount;
        }
    }
}

