using System;
public class Solution
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        while (n > 0)
        {
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
            {
                bool[] position = new bool[32];
                for (int i = 0; i < 32; i++)
                {
                    if ((num & (1 << i)) > 0)
                        position[i] = true;
                }
                int x = 0;
                bool start = false;
                int counter = 0;
                for (int i = 31; i >= 0; i--)
                {
                    if (!start && position[i])
                    {
                        start = true;
                        x += (int)Math.Pow(2, counter);
                        counter++;
                    }
                    else if (start && !position[i])
                    {
                        counter++;
                    }
                    else if (start && position[i])
                    {
                        x += (int)Math.Pow(2, counter);
                        counter++;
                    }
                }
                Console.WriteLine(x);
            }
            else
            {
                Console.WriteLine(num);
            }
            n--;
        }
    }
}

