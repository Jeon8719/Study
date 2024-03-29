using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            int number = int.Parse(Console.ReadLine());
            int result = CountGoldbachPartitions(number);
            sb.AppendLine(result.ToString());
        }
        Console.WriteLine(sb.ToString());
    }

    static int CountGoldbachPartitions(int n)
    {
        // 에라토스테네스의 체로 n까지의 소수를 구함
        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        for (int p = 2; p * p <= n; p++)
        {
            if (isPrime[p])
            {
                for (int i = p * p; i <= n; i += p)
                {
                    isPrime[i] = false;
                }
            }
        }

        // 소수 배열 생성
        int[] primes = new int[isPrime.Length];
        int index = 0;
        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i])
            {
                primes[index++] = i;
            }
        }

        // 골드바흐 파티션 계산
        int count = 0;
        int left = 0;
        int right = index - 1;

        while (left <= right)
        {
            if (primes[left] + primes[right] == n)
            {
                count++;
                left++;
                right--;
            }
            else if (primes[left] + primes[right] < n)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return count;
    }
}
