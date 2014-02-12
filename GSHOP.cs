using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class GSHOP
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
                string[] str = Console.ReadLine().Split();
                int n = int.Parse(str[0]);
                int k = int.Parse(str[1]);
                string[] strNum = Console.ReadLine().Split();
                int absMin = Int32.MaxValue;
                int[] num = new int[n];
                int totalNegativeItem = 0;
                for (int i = 0; i < n; i++)
                {
                    num[i] = int.Parse(strNum[i]);
                    if (Math.Abs(num[i]) < absMin)
                        absMin = Math.Abs(num[i]);
                    if (num[i] <= 0)
                        totalNegativeItem++;
                }
                long maxSum = 0;
                if (totalNegativeItem < k)
                {
                    int remainingK = k - totalNegativeItem;
                    for (int i = 0; i < n; i++)
                    {
                        maxSum += Math.Abs(num[i]);
                    }
                    if (remainingK % 2 != 0)
                    {
                        if (absMin == 0)
                        {
                        }
                        else
                        {
                            maxSum -= (2*absMin);
                        }
                    }
                    
                }
                else if (totalNegativeItem == k)
                {
                    for (int i = 0; i < n; i++)
                    {
                        maxSum += Math.Abs(num[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (i < k)
                        {
                            maxSum += Math.Abs(num[i]);
                        }
                        else
                        {
                            maxSum += num[i];
                        }
                    }
                }
                Console.WriteLine(maxSum);
                t--;
            }
        }
    }
}
