using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class ROBBERY2
    {
        static void Main()
        {
            Run();
        }
        static void Run()
        {
            int n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                string[] str = Console.ReadLine().Split();
                ulong num = ulong.Parse(str[0]);
                int k = int.Parse(str[1]);
                StringBuilder sb = new StringBuilder();
                ulong[] dist = new ulong[k];
                ulong min = 1;
                ulong max = num;
                while (min < max)
                {
                    ulong mid = min + (max - min + 1) / 2;
                    ulong sum = mid * (mid + 1);
                    if (sum <= num * 2)
                    {
                        min = mid ;
                    }
                    
                    else
                    {
                        max = mid - 1;
                    }
                }
                ulong remiainingCoins = num - ((min * (min + 1)) / 2);
                ulong totalRows = min / (ulong)k;
                ulong reminder = min % (ulong)k;
                for (int i = 1; i <= k; i++)
                {
                    dist[i - 1] = ((ulong)k * (totalRows - 1) * totalRows) / 2;
                    dist[i - 1] += (ulong)i * totalRows;
                    if (reminder >= (ulong)i)
                    {
                        dist[i - 1] += ((totalRows * (ulong)k) + (ulong)i);
                    }

                }
                if (remiainingCoins > 0)
                {
                    dist[reminder] += remiainingCoins;
                }

                for (int i = 0; i < k; i++)
                    sb.AppendFormat("{0} ", dist[i]);
                Console.WriteLine(sb.ToString().Trim());
                n--;
            }
        }
    }
}
