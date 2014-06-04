using System;

public class Test
{
    public static void Main()
    {
        // your code goes here
        int t = int.Parse(Console.ReadLine());
        while (t > 0)
        {
            string[] str = Console.ReadLine().Split();
            long a = long.Parse(str[0]);
            long b = long.Parse(str[1]);
            long gcd = GCD(Math.Max(a, b), Math.Min(a, b));
            long x = a / gcd;
            long y = b / gcd;
            if (a > b)
                Console.WriteLine(string.Format("{0} {1}", Math.Min(x, y), Math.Max(x, y)));
            else
                Console.WriteLine(string.Format("{0} {1}", Math.Max(x, y), Math.Min(x, y)));
            t--;
        }
    }

    static long GCD(long a, long b)
    {
        if (b == 0)
            return a;
        else
            return GCD(b, a % b);
    }
}
