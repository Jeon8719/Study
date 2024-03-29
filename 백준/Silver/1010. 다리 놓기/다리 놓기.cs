using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        int T = int.Parse(Console.ReadLine());

        for (int t = 0; t < T; t++)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int N = input[0]; // 서쪽 사이트 수
            int M = input[1]; // 동쪽 사이트 수

            int result = CalculateCombinations(N, M);
            sb.AppendLine(result.ToString());            
        }
        Console.WriteLine(sb.ToString());
    }

    static int CalculateCombinations(int n, int m)
    {
        // 이항 계수를 이용하여 조합을 계산
        int[,] dp = new int[n + 1, m + 1];

        for (int i = 0; i <= m; i++)
        {
            dp[0, i] = 1;
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j <= m; j++)
            {
                dp[i, j] = dp[i, j - 1] + dp[i - 1, j - 1];
            }
        }

        return dp[n, m];
    }
}
