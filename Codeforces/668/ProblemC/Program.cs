using System;
using System.Linq;

namespace ProblemC
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int tt = 0; tt < t; tt++)
            {
                int[] parts = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                int n = parts[0];
                int k = parts[1];
                int m = k / 2;

                var ss = Console.ReadLine();

                char[] s = ss.ToCharArray();

                bool ok = true;
                for (int i = 0; i + k < n; i++)
                {
                    if (s[i] == '0')
                    {
                        if (s[i + k] == '0')
                        {
                            continue;
                        }
                        
                        if (s[i + k] == '1')
                        {
                            ok = false;
                            break;
                        }

                        if (s[i + k] == '?')
                        {
                            s[i + k] = '0';
                        }
                    }

                    if (s[i] == '1')
                    {
                        if (s[i + k] == '1')
                        {
                            continue;
                        }

                        if (s[i + k] == '0')
                        {
                            ok = false;
                            break;
                        }

                        if (s[i + k] == '?')
                        {
                            s[i + k] = '1';
                        }
                    }

                    if (s[i] == '?')
                    {
                        s[i] = s[i + k];
                    }
                }

                if (!ok)
                {
                    Console.WriteLine("NO");
                    continue;
                }

                int ones = 0;
                int zeros = 0;
                int qs = 0;
                int len = 1;
                for (int i = 0; i < n; i++)
                {
                    switch (s[i])
                    {
                        case '0':
                            zeros++;
                            break;
                        case '1':
                            ones++;
                            break;
                        case '?':
                            qs++;
                            break;
                    }

                    if (len < k)
                    {
                        len++;
                        continue;
                    }

                    // len == k
                    int needZeros = m - zeros;
                    int needOnes = m - ones;

                    if (needOnes < 0 || needZeros < 0)
                    {
                        ok = false;
                        break;
                    }

                    if (needZeros + needOnes != qs)
                    {
                        ok = false;
                        break;
                    }

                    switch (s[i - k + 1])
                    {
                        case '0':
                            zeros--;
                            break;
                        case '1':
                            ones--;
                            break;
                        case '?':
                            qs--;
                            break;
                    }
                }

                if (ok)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }
    }
}
