using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    struct Street
    {
        public int length;
        public int endPoint;
    }
    class PriorityQ
    {
        int[] arrayKey;
        int[] arrayValue;
        private int count;
        private Dictionary<int, int> mapping;
        public PriorityQ(int capacity)
        {
            arrayKey = new int[capacity];
            count = 0;
            mapping = new Dictionary<int, int>();
            arrayValue = new int[capacity];
        }

        public bool isEmpty()
        {
            return this.count == 0;
        }


        private int LeftChild(int parentId)
        {
            int leftChildPostion = (parentId << 1) + 1;
            if (leftChildPostion < count)
                return leftChildPostion;
            return -1;
        }

        private int RightChild(int parentId)
        {
            int rightChildPosition = (parentId + 1) << 1;
            if (rightChildPosition < count)
                return rightChildPosition;
            return -1;
        }

        public bool Contains(int value)
        {
            return mapping.ContainsKey(value);
        }

        public KeyValuePair<int, int> ExtractMin()
        {
            int key;
            int value;
            if (arrayKey.Length == 0)
                return new KeyValuePair<int, int>(-1, -1);
            key = arrayKey[0];
            value = arrayValue[0];
            mapping.Remove(arrayValue[0]);
            Swap(0, this.count - 1);
            this.count--;
            PrecolateDown(0);
            return new KeyValuePair<int, int>(key, value);
        }

        public void Insert(int value, int key)
        {
            this.count++;
            int i = this.count - 1;
            arrayKey[i] = key;
            arrayValue[i] = value;
            mapping.Add(arrayValue[i], i);
            PrecolateUp(i);

        }

        public void Update(int value, int updatedKey)
        {
            int currentIndex = mapping[value];
            int currentKey = arrayKey[currentIndex];
            if (currentKey < updatedKey)
            {
                arrayKey[currentIndex] = updatedKey;
                PrecolateDown(currentIndex);
            }
            else
            {
                arrayKey[currentIndex] = updatedKey;
                PrecolateUp(currentIndex);
            }
        }

        private void Swap(int i, int j)
        {
            //update the dict mapping
            mapping[arrayValue[i]] = j;
            mapping[arrayValue[j]] = i;

            //swap keys
            int temp = arrayKey[i];
            arrayKey[i] = arrayKey[j];
            arrayKey[j] = temp;

            //swap values
            temp = arrayValue[i];
            arrayValue[i] = arrayValue[j];
            arrayValue[j] = temp;

        }

        void PrecolateUp(int i)
        {
            while (i > 0)
            {
                int parentId = (i - 1) >> 1;
                if (arrayKey[parentId] > arrayKey[i])
                {
                    Swap(parentId, i);
                    i = parentId;
                }
                else
                {
                    return;
                }
            }
        }

        void PrecolateDown(int i)
        {
            int left = LeftChild(i);
            int right = RightChild(i);
            int min;
            if (left != -1 && arrayKey[left] < arrayKey[i])
            {
                min = left;
            }
            else
            {
                min = i;
            }
            if (right != -1 && arrayKey[right] < arrayKey[min])
                min = right;
            if (min != i)
            {
                Swap(i, min);

            }
            else
                return;
            PrecolateDown(min);

        }


    }
    class CSTREET
    {
        static Dictionary<int, List<Street>> adj;
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
                adj = new Dictionary<int, List<Street>>();
                int price = int.Parse(Console.ReadLine());
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());
                for (int i = 0; i < m; i++)
                {
                    string[] str = Console.ReadLine().Split();
                    int a = int.Parse(str[0]) - 1;
                    int b = int.Parse(str[1]) - 1;
                    int l = int.Parse(str[2]);
                    if (!adj.ContainsKey(a))
                        adj.Add(a, new List<Street>());
                    if (!adj.ContainsKey(b))
                        adj.Add(b, new List<Street>());
                    adj[a].Add(new Street() { endPoint = b, length = l });
                    adj[b].Add(new Street() { endPoint = a, length = l });
                }
                int[] dist = new int[n];
                for (int i = 0; i < n; i++)
                    dist[i] = Int32.MaxValue;
                dist[0] = 0;
                PriorityQ pq = new PriorityQ(n);
                pq.Insert(0, 0);
                bool[] visited = new bool[n];
                while (!pq.isEmpty())
                {
                    var item = pq.ExtractMin();
                    int val = item.Value;
                    int d = item.Key;
                    visited[val] = true;
                    foreach (var a in adj[val])
                    {
                        if (visited[a.endPoint])
                            continue;
                        int newDist = d + a.length;
                        if (a.length < dist[a.endPoint])
                        {
                            if (pq.Contains(a.endPoint))
                            {
                                dist[a.endPoint] = a.length;
                                pq.Update(a.endPoint, dist[a.endPoint]);
                            }
                            else
                            {
                                dist[a.endPoint] = a.length;
                                pq.Insert(a.endPoint, dist[a.endPoint]);
                            }
                        }
                    }
                }
                long finalLen = 0;
                for (int i = 0; i < n; i++)
                    finalLen += dist[i];
                Console.WriteLine(finalLen * price);
                t--;
            }
        }
    }
}

