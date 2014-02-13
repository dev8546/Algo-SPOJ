﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions.DP
{
    class ACODE
    {
        static void Main(string[] args)
        {
            Run();
        }
        static int[] cache;
        static void Run()
        {
            while (true)
            {
                string str = Console.ReadLine();
                if (string.Compare(str, "0", true) == 0)
                    break;
                cache = new int[str.Length];
                Console.WriteLine(DP(str, 0));
            }
        }
        static int DP(string str, int startIndex)
        {
            int c1 = 0, c2 = 0;
            if (startIndex > str.Length - 1)
            {
                return 1;
            }
            else if (startIndex == str.Length - 1)
            {
                if (int.Parse(str[startIndex].ToString()) == 0)
                    return 0;
                else
                    return 1;
            }
            if (cache[startIndex] > 0)
                return cache[startIndex];
            int t1 = int.Parse(str[startIndex].ToString());
            if (t1 > 0)
            {
                c1 = DP(str, startIndex + 1);
                if (int.Parse(str.Substring(startIndex, 2)) <= 26)
                    c2 = DP(str, startIndex + 2);
                cache[startIndex] = c1 + c2;
            }
            return c1 + c2;
        }
    }
}

