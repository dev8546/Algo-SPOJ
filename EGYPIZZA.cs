using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class EGYPIZZA
    {
        static void Main()
        {
            Run();
            Console.ReadLine();
        }
        static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int[] num = new int[3]; // 0 => .25 , 1 => .50 , 2 => .75
            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine().Trim();
                if (str == "1/4")
                    num[0]++;
                else if (str == "1/2")
                    num[1]++;
                else
                    num[2]++;
            }
            int totalPizzaz = 0;
            if (num[0] >= num[2])
            {
                totalPizzaz += num[2];
                num[0] -= num[2];
                num[2] = 0;
            }
            else
            {
                totalPizzaz += num[0];
                num[2] -= num[0];
                num[0] = 0;
            }

            int p = num[0] / 2;
            if (p >= num[1])
            {
                totalPizzaz += num[1];
                num[0] -= (2 * num[1]);
                num[1] = 0;
            }
            else
            {
                totalPizzaz += p;
                num[1] -= p;
                num[0] -= ((p * 2));
                if (num[1] > 0 && num[0] > 0)
                {
                    num[0] = 0;
                    totalPizzaz++;
                    num[1]--;
                }
            }

            totalPizzaz += (num[1] / 2) + (num[1] % 2);
            totalPizzaz += num[2];
            totalPizzaz += (num[0] / 4) + (num[0] % 4);
            Console.WriteLine(totalPizzaz + 1);
        }
    }
}

