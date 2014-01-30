using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    struct Street
    {
        public int dest;
        public int distance;
    }
    class BENEFACT
    {
        static Dictionary<int, bool> visited;
        static Dictionary<int, List<Street>> mapping;
        static void Main()
        {
            Run();
            Console.ReadLine();
        }
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            int N = -1;
            while (t > 0)
            {
                N = int.Parse(Console.ReadLine());
                mapping = new Dictionary<int, List<Street>>();
                for (int i = 1; i < N; i++)
                {
                    string[] data = Console.ReadLine().Split();
                    int s1 = int.Parse(data[0]);
                    int e1 = int.Parse(data[1]);
                    int l = int.Parse(data[2]);
                    if (!mapping.ContainsKey(s1))
                    {
                        mapping.Add(s1, new List<Street>());
                    }
                    mapping[s1].Add(new Street() { dest = e1, distance = l });
                    if (!mapping.ContainsKey(e1))
                        mapping.Add(e1, new List<Street>());
                    mapping[e1].Add(new Street() { dest = s1, distance = l });
                }

                visited = new Dictionary<int, bool>();
                overlmaxDist = 0;
                foreach (var item in mapping)
                {
                    if (visited.ContainsKey(item.Key))
                        continue;
                    DFS(item.Key);


                }
                Console.WriteLine(overlmaxDist);
                t--;
            }
        }
        static int overlmaxDist = 0;
        static int DFS(int key)
        {
            int maxDistance = 0;
            int secondBest = 0;
            visited.Add(key, true);
            foreach (var item in mapping[key])
            {
                if (!visited.ContainsKey(item.dest))
                {
                    int localDist = DFS(item.dest) + item.distance;
                    if (localDist >= maxDistance)
                    {
                        secondBest = maxDistance;
                        maxDistance = localDist;

                    }
                    else if (localDist > secondBest)
                        secondBest = localDist;
                }
            }
            overlmaxDist = overlmaxDist > secondBest + maxDistance ? overlmaxDist : secondBest + maxDistance;
            return maxDistance;
        }
    }
}

