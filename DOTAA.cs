using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class DOTAA
    {
        static void Main()
        {
            Run();
        }
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string[] str = Console.ReadLine().Split();
                int totalHeros = int.Parse(str[0]);
                int totalTowers = int.Parse(str[1]);
                int Damage = int.Parse(str[2]);
                int[] heroHealth = new int[totalHeros];
                for (int i = 0; i < totalHeros; i++)
                {
                    heroHealth[i] = int.Parse(Console.ReadLine());
                }
                Array.Sort(heroHealth);
                bool isPossible = false;
                int totalTowersCross = 0;
                for (int i = totalHeros - 1; i >= 0; i--)
                {
                    totalTowersCross += (int)Math.Ceiling((float)heroHealth[i] / Damage) - 1;
                    if (totalTowersCross >= totalTowers)
                    {
                        isPossible = true;
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

