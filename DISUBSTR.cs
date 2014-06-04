using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPOJSolutions
{
    struct suffix : IComparable<suffix>
    {
        public int index;
        public int[] rank;
        public int CompareTo(suffix s)
        {
            if (this.rank[0] == s.rank[0])
                return this.rank[1] == s.rank[1] ? this.index.CompareTo(s.index) : this.rank[1].CompareTo(s.rank[1]);
            return this.rank[0].CompareTo(s.rank[0]);
        }
    }
    class SuffixArray
    {
        static int[] BuildSuffixArray(string str)
        {
            int len = str.Length;
            suffix[] s = new suffix[len];
            for (int i = 0; i < len; i++)
            {
                s[i].rank = new int[2];
                s[i].index = i;
                s[i].rank[0] = (int)str[i] - (int)'A';
                s[i].rank[1] = i + 1 < len ? (int)str[i + 1] - (int)'A' : -1;
            }
            Array.Sort(s); // sorted by first two char ...


            int[] ind = new int[len];
            for (int i = 4; i < len; i *= 2)
            {
                int rank = 0;
                int prevRank = s[0].rank[0];
                s[0].rank[0] = rank;
                ind[s[0].index] = 0;

                //totalCount++;
                for (int j = 1; j < len; j++)
                {
                    if (s[j].rank[0] == prevRank && s[j].rank[1] == s[j - 1].rank[1])
                    {
                        s[j].rank[0] = rank;
                    }
                    else
                    {
                        prevRank = s[j].rank[0];
                        s[j].rank[0] = ++rank;
                    }
                    ind[s[j].index] = j;
                }
                for (int j = 0; j < len; j++)
                {
                    int nextIndex = s[j].index + i / 2;
                    s[j].rank[1] = nextIndex < len ? s[ind[nextIndex]].rank[0] : -1;
                }
                Array.Sort(s);
            }
            int[] suffixarray = new int[len];
            for (int i = 0; i < len; i++)
            {
                suffixarray[i] = s[i].index;
            }
            return suffixarray;
        }
        static long tCount = 0;
        static void LCP(int[] suffixarr, string str)
        {
            //tCount = str.Substring(suffixarr[0]).Length;
            for (int i = 0; i < suffixarr.Length - 1; i++)
            {
                string strOne = str.Substring(suffixarr[i]);
                string strTwo = str.Substring(suffixarr[i + 1]);
                int minLen = Math.Min(strOne.Length, strTwo.Length);
                int counter = 0;
                for (int j = 0; j < minLen; j++)
                {
                    if (strOne[j] == strTwo[j])
                    {
                        counter++;
                    }
                    else
                        break;
                }
                tCount += counter;
            }
        }

        static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string str = Console.ReadLine().Trim();
                tCount = 0;
                var sarr = BuildSuffixArray(str);
                LCP(sarr, str);
                int len = str.Length;
                long total = (len * (len + 1)) / 2;
                Console.WriteLine(total - tCount);
                t--;
            }

        }
    }
}




