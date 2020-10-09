using System;
using System.Linq;

namespace ProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            while (--t >= 0)
            {
                int[] parts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int n = parts[0];
                int m = parts[1];

                int[,] a = new int[n, m];
                bool[,] solved = new bool[n, m];
                for (int i = 0; i < n; i++)
                {
                    parts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                    for (int j = 0; j < m; j++)
                    {
                        a[i, j] = parts[j];
                    }
                }

                long cost = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (solved[i, j])
                        {
                            continue;
                        }

                        if (i < n / 2 && j < m / 2)
                        {
                            int i1 = n - i - 1;
                            int j1 = m - j - 1;
                            cost += Cost(a[i, j], a[i, j1], a[i1, j], a[i1, j1]);
                            solved[i, j] = solved[i, j1] = solved[i1, j] = solved[i1, j1] = true;
                            continue;
                        }

                        if (i < n / 2)
                        {
                            cost += Cost(a[i, j], a[n - i - 1, j]);
                            solved[i, j] = solved[n - i - 1, j] = true;
                            continue;
                        }

                        if (j < m / 2)
                        {
                            cost += Cost(a[i, j], a[i, m - j - 1]);
                            solved[i, j] = solved[i, m - j - 1] = true;
                        }
                    }
                }

                Console.WriteLine(cost);
            }
        }

        static long Cost(int a, int b, int c, int d)
        {
            long[] m = {a, b, c, d};

            long min = long.MaxValue;

            for (int i = 0; i < 4; i++)
            {
                long cur = 0;
                for (int j = 0; j < 4; j++)
                {
                    cur += Math.Abs(m[i] - m[j]);
                }

                if (cur < min)
                {
                    min = cur;
                }
            }

            return min;
        }

        static long Cost(int a, int b)
        {
            return Math.Abs(a - b);
        }
    }
}
