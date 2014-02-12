using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class TIPTOP
    {
        static void Main()
        {
            Run();
            Console.ReadLine();
        }
        // Same appraoch is passing in C++ but TLE in C# because of t times of loop.
        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            int caseNum = 1;
            while (t > 0)
            {
                ulong num = ulong.Parse(Console.ReadLine());
                ulong sqrt = (ulong)Math.Sqrt(num);
                if((sqrt * sqrt) == num)
                    Console.WriteLine(string.Format("Case {0}: Yes",caseNum));
                else
                    Console.WriteLine(string.Format("Case {0}: No", caseNum));
                caseNum++;
                t--;
            }
        }
    }
}
//C++ implementation
/*
#include <iostream>
#include <stdio.h>
#include <math.h>
using namespace std;

int main() {
	// your code goes here
	int t;
	scanf("%d",&t);
	int caseNum = 1;
	while ( t  > 0)
	{
		long long num ;
		scanf("%lld" , &num);
		long long sq = sqrt(num);
		if(sq * sq == num)
			printf("Case %d: Yes\n",caseNum);
		else
				printf("Case %d: No\n",caseNum);
		caseNum++;
		t--;
	}
	return 0;
}

 */
