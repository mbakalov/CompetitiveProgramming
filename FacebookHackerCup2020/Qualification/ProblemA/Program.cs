using System;
using System.IO;

namespace ProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new StreamReader("input.txt");
            var output = new StreamWriter("output.txt");

            int T = int.Parse(input.ReadLine());

            for (int t = 0; t < T; t++)
            {
                int N = int.Parse(input.ReadLine());

                bool[,] G = new bool[N, N];
                for (int i = 0; i < N - 1; i++) G[i, i] = G[i, i + 1] = G[i + 1, i] = true;

                G[N - 1, N - 1] = true;

                // inbound
                var s = input.ReadLine();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'N')
                    {
                        if (i > 0) G[i - 1, i] = false;
                        if (i < N - 1) G[i + 1, i] = false;
                    }
                }

                // outbound
                s = input.ReadLine();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'N')
                    {
                        if (i > 0) G[i, i - 1] = false;
                        if (i < N - 1) G[i, i + 1] = false;
                    }
                }

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            if (G[i, k] && G[k, j]) G[i, j] = true;
                        }
                    }
                }

                output.WriteLine($"Case #{t + 1}:");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        output.Write(G[i, j] ? 'Y' : 'N');
                    }

                    output.WriteLine();
                }
            }

            input.Close();
            output.Close();
        }
    }
}
