﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class DCRYPT
    {
        public static void Main()
        {
            Run();
        }

        static void Run()
        {
            string masterstr = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Dictionary<int, char> mapping = new Dictionary<int, char>();
            for (int i = 0; i < 52; i++)
                mapping.Add(i, masterstr[i]);
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                int encyptkey = int.Parse(Console.ReadLine());
                string encyptStr = Console.ReadLine();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < encyptStr.Length; i++)
                {
                    if (encyptStr[i] == '.')
                        sb.Append(" ");
                    else
                    {
                        int charAsciiCode = (int)encyptStr[i];
                        int keymapping = -1;
                        if (charAsciiCode > 96)
                        {
                            keymapping = ((charAsciiCode - 97) + encyptkey) % 26;
                        }
                        else
                        {
                            keymapping = (((charAsciiCode - 65) + encyptkey) % 26) + 26;
                        }
                        if (encyptkey < 26)
                        {
                            sb.Append(mapping[keymapping]);
                        }
                        else
                        {
                            keymapping = charAsciiCode > 96 ? keymapping + 26 : keymapping - 26;
                            sb.Append(mapping[keymapping]);
                        }

                    }
                }
                Console.WriteLine(sb.ToString());
                t--;
            }
        }
    }
}

