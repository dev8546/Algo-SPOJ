using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    struct S :  IComparable
    {
        public int StartTime;
        public int EndTime;
        public int Payment;
        public int CompareTo(Object obj)
        {
            S s = (S)obj;
            if (this.EndTime < s.EndTime)
                return -1;
            return 1;
        }
    }
    class RENT
    {
        public static void Main()
        {
            Run();
        }
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                int totalOrders = int.Parse(Console.ReadLine());
                S[] orders = new S[totalOrders];
                for (int i = 0; i < totalOrders; i++)
                {
                    string[] str = Console.ReadLine().Split();
                    orders[i].StartTime = int.Parse(str[0]);
                    orders[i].EndTime = orders[i].StartTime + int.Parse(str[1]);
                    orders[i].Payment = int.Parse(str[2]);
                }
                Array.Sort(orders);
                int[] DP = new int[totalOrders + 1];
                DP[0] = orders[0].Payment;
                for (int i = 1; i < totalOrders; i++)
                {
                    int place = BSearch(orders, orders[i].StartTime);
                    if (place == 0)
                    {
                        DP[i] =  Math.Max(orders[i].Payment,DP[i-1]);
                    }
                    else
                    {
                        if (DP[place-1] + orders[i].Payment > DP[i-1])
                        {
                            DP[i] = DP[place-1] + orders[i].Payment;
                        }
                        else
                        {
                            DP[i] = DP[i - 1];
                        }
                    }
                }
                Console.WriteLine(DP[totalOrders - 1]);
                t--;
            }
            Console.ReadLine();
        }

        static int BSearch(S[] orders, int val)
        {
            int startIndex = 0;
            int endIndex = orders.Length - 1;
            while (startIndex <= endIndex)
            {
                int mid = startIndex + (endIndex - startIndex) / 2;
                if (orders[mid].EndTime <= val)
                {
                    startIndex = mid + 1;
                }
                else
                {
                    endIndex = mid-1;
                }
            }
            return startIndex;
        }
    }
}
