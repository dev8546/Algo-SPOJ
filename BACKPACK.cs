using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgoSolution
{
    struct Goods
    {
        public int Weight;
        public int Value;
        public List<int> attachmentIds;
        public bool isAttachment;
    }
    class BACKPACK
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
                int vMax = int.Parse(str[0]);
                int N = int.Parse(str[1]);

                Goods[] goods = new Goods[N];
                int totalItemToConsiser = 0;
                for (int i = 0; i < N; i++)
                {
                    string[] strGood = Console.ReadLine().Split();
                    int weight = int.Parse(strGood[0]);
                    int value = int.Parse(strGood[1]);
                    int parent = int.Parse(strGood[2]);
                    goods[i].attachmentIds = new List<int>();
                    if (parent == 0)
                    {
                        goods[i].isAttachment = false;
                        totalItemToConsiser++;
                    }
                    else
                    {
                        goods[i].isAttachment = true;
                        goods[parent - 1].attachmentIds.Add(i);
                    }
                    goods[i].Weight = weight;
                    goods[i].Value = value;


                }
                //base case
                int[,] dp = new int[totalItemToConsiser, vMax + 1];
                int totalAttachMent = goods[0].attachmentIds.Count;
                int counter = 0;
                for (int i = 0; i <= vMax; i++)
                {
                    int maxVal = 0;
                    if (i >= goods[0].Weight)
                    {
                        maxVal = Math.Max(maxVal, goods[0].Value * goods[0].Weight);
                    }
                    if (counter < totalAttachMent)
                    {
                        if (i >= goods[goods[0].attachmentIds[counter]].Weight + goods[0].Weight)
                        {
                            maxVal = Math.Max(maxVal, (goods[goods[0].attachmentIds[counter]].Value * goods[goods[0].attachmentIds[counter]].Weight) + (goods[0].Value * goods[0].Weight));
                        }
                        counter++;
                    }
                    if (totalAttachMent == 2)
                    {
                        int attachementOneWeight = goods[goods[0].attachmentIds[0]].Weight;
                        int attachementTwoWeight = goods[goods[0].attachmentIds[1]].Weight;

                        int attachementOneValue = goods[goods[0].attachmentIds[0]].Value;
                        int attachementTwoValue = goods[goods[0].attachmentIds[1]].Value;
                        if (i >= attachementOneWeight + attachementTwoWeight + goods[0].Weight)
                        {
                            maxVal = Math.Max(maxVal, attachementOneValue * attachementOneWeight + attachementTwoValue * attachementTwoWeight + goods[0].Weight * goods[0].Value);
                        }
                    }
                    counter = 0;
                    dp[0, i] = maxVal;
                }
                int item = 1;
                for (int j = 1; j < N; j++)
                {
                    if (goods[j].isAttachment)
                        continue;

                    totalAttachMent = goods[j].attachmentIds.Count;
                    counter = 0;
                    for (int i = 0; i <= vMax; i++)
                    {
                        int maxVal = 0;
                        if (i >= goods[j].Weight)
                        {
                            maxVal = Math.Max(maxVal, (goods[j].Value * goods[j].Weight) + dp[item - 1, i - goods[j].Weight]);
                        }
                        if (counter < totalAttachMent)
                        {
                            if (i >= goods[goods[j].attachmentIds[counter]].Weight + goods[j].Weight)
                            {
                                maxVal = Math.Max(maxVal, (goods[goods[j].attachmentIds[counter]].Value * goods[goods[j].attachmentIds[counter]].Weight) + (goods[j].Value * goods[j].Weight) + dp[item - 1, i - (goods[goods[j].attachmentIds[counter]].Weight + goods[j].Weight)]);
                            }
                            counter++;
                        }
                        if (totalAttachMent == 2)
                        {
                            int attachementOneWeight = goods[goods[j].attachmentIds[0]].Weight;
                            int attachementTwoWeight = goods[goods[j].attachmentIds[1]].Weight;

                            int attachementOneValue = goods[goods[j].attachmentIds[0]].Value;
                            int attachementTwoValue = goods[goods[j].attachmentIds[1]].Value;
                            if (i >= attachementOneWeight + attachementTwoWeight + goods[j].Weight)
                            {
                                maxVal = Math.Max(maxVal, attachementOneValue * attachementOneWeight + attachementTwoValue * attachementTwoWeight + goods[j].Weight * goods[j].Value + dp[item - 1, i - (attachementTwoWeight + attachementOneWeight + goods[j].Weight)]);
                            }
                        }
                        dp[item, i] = Math.Max(maxVal, dp[item - 1, i]);
                        counter = 0;
                    }
                    item++;

                }
                Console.WriteLine(dp[totalItemToConsiser - 1, vMax]);
                t--;
            }
        }
    }
}
