using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    class ABSP1
    {
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
                long[] num = new long[n];
                string[] str = Console.ReadLine().Split();
                long totalSum = 0;
                for (int i = 0; i < n; i++)
                {
                    num[i] = long.Parse(str[i]);
                    totalSum += num[i];
                }
                int m = n - 1;
                long avg = 0;
                for (int i = 1; i <= n - 1; i++)
                {
                    totalSum -= num[i - 1];
                    avg += (totalSum - (num[i - 1] * m));
                    m--;
                }
                Console.WriteLine(avg);
                t--;
            }
        }
    }
}

