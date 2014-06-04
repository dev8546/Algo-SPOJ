using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    class COLONY
    {
        static long pos(long position, int largestpower)
        {

            return largestpower >= 0 ? position - (long)Math.Pow(2, largestpower) : position; ;
        }
        static void Main()
        {
            int t = 1;//int.Parse(Console.ReadLine());
            while (t > 0)
            {
                t--;
                int year = int.Parse(Console.ReadLine());
                long position = long.Parse(Console.ReadLine());
                position = (long)Math.Pow(2, year) - position;
                if (year == 0)
                    Console.WriteLine("red");
                else
                {
                    long remaining = position;
                    int largestpower = 0;
                    for (int i = 0; i < 64; i++)
                    {
                        long pow = (long)Math.Pow(2, i);
                        if (pow >= position)
                        {
                            largestpower = i;
                            break;
                        }
                    }
                    string[] color = new string[] { "red" };
                    bool current = true;
                    while (remaining > 1)
                    {

                        remaining = pos(remaining, --largestpower);
                        for (int i = 0; i < 64; i++)
                        {
                            long pow = (long)Math.Pow(2, i);
                            if (pow >= remaining)
                            {
                                largestpower = i;
                                break;
                            }
                        }
                        current = !current;

                    }
                    if (current)
                        Console.WriteLine("red");
                    else
                        Console.WriteLine("blue");
                }
            }


        }
    }
}

