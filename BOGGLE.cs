using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoSolution
{
    class BOGGLE
    {
        static int Point(string word)
        {
            int len = word.Length;
            if (len <= 4)
                return 1;
            if (len == 5)
                return 2;
            if (len == 6)
                return 3;
            if (len == 7)
                return 5;
            return 11;

        }
        static void Main()
        {
            Run();
            Console.ReadLine();
        }
        static void Run()
        {
            int players = int.Parse(Console.ReadLine());
            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            Dictionary<int,string[]> data = new Dictionary<int,string[]>();
            for (int i = 0; i < players; i++)
            {
                string[] words = Console.ReadLine().Split();
                data.Add(i,words);
                for (int j = 0; j < words.Length; j++)
                {
                    if (dict.ContainsKey(words[j]))
                        dict[words[j]] = true;
                    else
                        dict.Add(words[j], false);
                }
            }
            int maxPoint = Int32.MinValue;
            int localPoint = 0;
            for (int i = 0; i < players; i++)
            {
                string[] w = data[i];
                localPoint = 0;
                for (int j = 0; j < w.Length; j++)
                {
                    if (!dict[w[j]])
                        localPoint += Point(w[j]);
                }
                if (localPoint > maxPoint)
                    maxPoint = localPoint;
            }
            Console.WriteLine(maxPoint);
        }
    }
}
