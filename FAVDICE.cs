using System;

public class Test
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        decimal[] dp = new decimal[1001];
        decimal total = 0;
        for (int i = 1; i <= 1000; i++)
        {
            total += 1 / (decimal)i;
            dp[i] = total;
        }
        while (t > 0)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Format("{0:0.00}", n * dp[n]));
            t--;
        }
    }
}
