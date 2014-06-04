using System;

public class Test
{
    public static void Main()
    {
        long[] count = new long[1000001];
        count[1] = 2;
        for (long i = 2; i <= 1000000; i++)
        {
            count[i] = (count[i - 1]);
            count[i] = (count[i] + i - 1) % 1000007;
            count[i] = (count[i] + (2 * i)) % 1000007;
        }
        int t = int.Parse(Console.ReadLine());
        while (t > 0)
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(count[n]);
            t--;
        }
    }
}


