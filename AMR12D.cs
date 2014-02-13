using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    class AMR12D
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
                string str = Console.ReadLine();
                bool isPossible = true;
                for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
                {
                    if (str[i] != str[j])
                    {
                        isPossible = false;
                        break;
                    }
                }
                if (isPossible)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
                t--;
            }
        }
    }
}


