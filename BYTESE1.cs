using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
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
    struct Cell
    {
        public int positionId;
        public int cost;
    }
    class BYTESE1
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
                string[] str = Console.ReadLine().Split();
                int M = int.Parse(str[0]);
                int N = int.Parse(str[1]);
                int[,] overPowerCost = new int[M, N];
                Dictionary<int, List<Cell>> dict = new Dictionary<int, List<Cell>>();
                for (int i = 0; i < M; i++)
                {
                    string[] strCost = Console.ReadLine().Split();
                    for (int j = 0; j < N; j++)
                    {
                        overPowerCost[i, j] = int.Parse(strCost[j]);
                    }
                }
                string[] strLastLine = Console.ReadLine().Split();
                int x = int.Parse(strLastLine[0]);
                int y = int.Parse(strLastLine[1]);
                int T = int.Parse(strLastLine[2]);
                int finalPosition = (x - 1) * N + (y - 1);
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        int key = i * N + j;
                        dict.Add(key, new List<Cell>());
                        if (i - 1 >= 0)
                        {
                            dict[key].Add(new Cell() { cost = overPowerCost[i - 1, j], positionId = (i - 1) * N + j });
                        }
                        if (i + 1 < M)
                        {
                            dict[key].Add(new Cell() { cost = overPowerCost[i + 1, j], positionId = (i + 1) * N + j });
                        }
                        if (j - 1 >= 0)
                        {
                            dict[key].Add(new Cell() { cost = overPowerCost[i, j - 1], positionId = i * N + (j - 1) });
                        }
                        if (j + 1 < N)
                        {
                            dict[key].Add(new Cell() { cost = overPowerCost[i, j + 1], positionId = i * N + (j + 1) });
                        }
                    }

                }
                int[] dist = new int[M * N];
                PriorityQ pq = new PriorityQ(M * N);
                for (int i = 0; i < M * N; i++)
                    dist[i] = Int32.MaxValue;
                dist[0] = overPowerCost[0, 0];
                pq.Insert(0, dist[0]);
                while (!pq.isEmpty())
                {
                    KeyValuePair<int, int> currentCell = pq.ExtractMin();
                    if (currentCell.Value == finalPosition)
                    {
                        break;
                    }
                    foreach (var neighbour in dict[currentCell.Value])
                    {
                        if (neighbour.cost + dist[currentCell.Value] < dist[neighbour.positionId])
                        {
                            int newTime = neighbour.cost + dist[currentCell.Value];
                            dist[neighbour.positionId] = newTime;
                            if (pq.Contains(neighbour.positionId))
                            {
                                pq.Update(neighbour.positionId, newTime);
                            }
                            else
                            {
                                pq.Insert(neighbour.positionId, newTime);
                            }
                        }
                    }

                }
                if ((dist[finalPosition]) <= T)
                {
                    Console.WriteLine("YES");
                    Console.WriteLine(T - (dist[finalPosition]));
                }
                else
                    Console.WriteLine("NO");
                t--;
            }
        }
    }
}

