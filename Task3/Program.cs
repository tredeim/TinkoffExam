using System;
using System.Linq;


class Program
{
    static void Main()
    {
        var input = Console.ReadLine().Split();
        var n = int.Parse(input[0]);
        var m = long.Parse(input[1]);
        var a = new long[] {0}.Concat(Array.ConvertAll(Console.ReadLine().Split(), long.Parse)).ToArray();
        var dp = Enumerable.Repeat(m, n + 1).ToArray();
        var currSum = new long[n + 1];
        
        for (var i = 1; i <= n; i++)
        {
            if (dp[i - 1] - currSum[i - 1] - a[i] < 0 || dp[i - 1] - currSum[i - 1] - a[i] > a[i] - 1)
            {
                dp[i] = dp[i - 1];
                currSum[i] = currSum[i - 1];
                if (dp[i - 1] - currSum[i - 1] - a[i] >= 0)
                {
                    currSum[i] += a[i];
                }
            }
            else
            {
                dp[i] = currSum[i - 1] + a[i] - 1;
                currSum[i] = currSum[i - 1];
            }
        }

        Console.WriteLine(dp[n] - currSum[n]);
    }
}
