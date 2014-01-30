using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class DCEPC206
    {
        static long[] tree;
        static void Update(int idx, int val, int maxVal)
        {
            while (idx <= maxVal)
            {
                tree[idx] += val;
                idx += (idx & -idx);
            }
        }

        static long Sum(int idx)
        {
            long sum = 0;
            while (idx > 0)
            {
                sum += tree[idx];
                idx -= (idx & -idx);
            }
            return sum;
        }
        static void Main()
        {
            Run();
            Console.ReadLine();
        }
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                int n = int.Parse(Console.ReadLine());
                tree = new long[1000001];
                string[] str = Console.ReadLine().Split();
                long totalSum = 0;
                for (int i = 0; i < n; i++)
                {
                    int num = int.Parse(str[i]);
                    if (num > 0)
                    {
                        Update(num, num, 1000001);
                        totalSum += Sum(num - 1);
                    }
                }
                Console.WriteLine(totalSum);
                t--;
            }
        }
    }
}

