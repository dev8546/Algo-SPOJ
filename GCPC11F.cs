using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class GCPC11F
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
                int[] anum = new int[26];
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                        continue;
                    int charAsciiCode = (int)str[i];
                    anum[charAsciiCode - 65]++;
                }
                int maxAsciiCode = -1;
                int maxVal = 0;
                int numberofTime = 0;
                for (int i = 0; i < 26; i++)
                {
                    if (maxVal < anum[i])
                    {
                        maxVal = anum[i];
                        maxAsciiCode = i;
                        numberofTime = 1;
                    }
                    else if (maxVal == anum[i])
                    {
                        numberofTime++;
                    }
                }
                int dist = (maxAsciiCode + 65) - 69;
                // This is tricky , we always have to calculate the distance in forward moving fashion
                if (dist < 0)
                {
                    dist = 26 + dist;
                }
                if (numberofTime > 1)
                    Console.WriteLine("NOT POSSIBLE");
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("{0} ", dist);
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == ' ')
                            sb.Append(" ");
                        else
                        {
                            int ascii = (int)str[i];
                            int decrypted = ascii - dist;
                            if (decrypted < 65)
                            {
                                int changedOne = 64 - decrypted;
                                sb.AppendFormat("{0}" ,Convert.ToChar(90 - changedOne));
                            }
                            else
                            {
                                sb.AppendFormat("{0}", Convert.ToChar(decrypted));
                            }
                        }
                    }
                    Console.WriteLine(sb.ToString().Trim());
                }
                t--;
            }
        }
    }
}
