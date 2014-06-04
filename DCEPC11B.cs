using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    class DCEPC11B
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                int[] num = Console.ReadLine().Trim().Split().Select(x => int.Parse(x)).ToArray();
                if (num[0] >= num[1])
                    Console.WriteLine(0);
                else
                {
                    long prevVal = 1;
                    for (int i = num[0] + 1; i < num[1]; i++)
                    {
                        prevVal = ((prevVal % num[1]) * i) % num[1];
                    }
                    prevVal = -1 * modInverse(prevVal, num[1]) + num[1];
                    Console.WriteLine(prevVal % num[1]);
                }
                t--;
            }
        }
        public static long modPow(long a, long x, long p)
        {
            //calculates a^x mod p in logarithmic time.
            long res = 1;
            while (x > 0)
            {
                if (x % 2 != 0)
                {
                    res = (res * a) % p;
                }
                a = (a * a) % p;
                x /= 2;
            }
            return res;
        }

        public static long modInverse(long a, long p)
        {
            //calculates the modular multiplicative of a mod m.
            //(assuming p is prime).
            return modPow(a, p - 2, p);
        }
    }
}

