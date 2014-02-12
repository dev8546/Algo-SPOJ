using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class HANGOVER
    {
        static void Main()
        {
            Run();
        }
        static void Run()
        {
            while (true)
            {
                double num = double.Parse(Console.ReadLine());
                if (num == 0)
                    break;
                int min = 1;
                int max = 400;
                double sum = 0;
                while (min < max)
                {
                    int mid = min + (max - min) / 2;
                    sum = 0;
                    for (int i = 0; i < mid; i++)
                    {
                        sum += 1.0 / ((double)(i + 2));
                    }
                    if (Math.Round(sum, 3) < num)
                        min = mid + 1;
                    else
                        max = mid;
                }
                Console.WriteLine(string.Format("{0} card(s)", min));
            }
        }
    }
}

