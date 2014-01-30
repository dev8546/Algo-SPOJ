using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class ACPC10D
    {
        static void Main()
        {
            Run();
        }
        static void Run()
        {
            int t = 1;
            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                if (n == 0)
                    break;
                int[] stage = new int[3];
                //base case
                string[] str = Console.ReadLine().Split();
                stage[0] = Int32.MaxValue;
                stage[1] = int.Parse(str[1]);
                stage[2] = Int32.MaxValue;
                if (int.Parse(str[2]) + stage[1] < stage[1])
                {
                    stage[2] = int.Parse(str[2]) + stage[1];
                }
                for (int i = 1; i < n; i++)
                {
                    str = Console.ReadLine().Split();
                    int min0 = Math.Min(stage[0], stage[1]);
                    min0 += int.Parse(str[0]);
                    int min1 = Math.Min(Math.Min(stage[0], stage[1]), stage[2]);
                    min1 = Math.Min(min1, min0);
                    min1 += int.Parse(str[1]);
                    int min2 = Math.Min(Math.Min(stage[1], stage[2]), min1);
                    min2 += int.Parse(str[2]);
                    stage[0] = min0;
                    stage[1] = min1;
                    stage[2] = min2;
                }
                Console.WriteLine(string.Format("{0}. {1}", t, stage[1]));
                t++;
            }
        }
    }
}

