using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class BYTESM2
    {
     
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string[] str = Console.ReadLine().Split();
                int row = int.Parse(str[0]);
                int column = int.Parse(str[1]);
                int[,] dp = new int[row, column];
                for (int i = 0; i < row; i++)
                {
                    string[] strC = Console.ReadLine().Split();
                    if (i == 0)
                    {
                        for (int j = 0; j < column; j++)
                            dp[i, j] = int.Parse(strC[j]);
                    }
                    else
                    {
                        for (int j = 0; j < column; j++)
                        {
                            int n = int.Parse(strC[j]);
                            int mVal = -1;
                            if (j - 1 >= 0 && dp[i-1,j-1] > mVal)
                            {
                                mVal = dp[i - 1, j - 1];
                            }
                            if (j + 1 < column && dp[i - 1, j + 1] > mVal)
                            {
                                mVal = dp[i - 1, j + 1];
                            }
                            if (dp[i - 1, j] > mVal)
                            {
                                mVal = dp[i - 1, j];
                            }
                            dp[i, j] = mVal + n;
                        }
                    }
                }
                int maxVal = Int32.MinValue;
                for (int j = 0; j < column; j++)
                {
                    if (dp[row - 1, j] > maxVal)
                        maxVal = dp[row - 1, j];
                }
                Console.WriteLine(maxVal);
                t--;
            }
        }
    }
}
