using System;
using System.IO;

namespace B
{
    /// <summary>
    /// https://codeforces.com/contest/1375/problem/B
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            var output = Console.Out;

//#if DEBUG
//            input = new StreamReader("input.txt");
//            output = new StreamWriter("output.txt");
//#endif

            int t = int.Parse(input.ReadLine());

            for (int tt = 0; tt < t; tt++)
            {
                bool ok = true;

                var ss = input.ReadLine().Split(' ');
                int n = int.Parse(ss[0]);
                int m = int.Parse(ss[1]);

                var a = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    ss = input.ReadLine().Split(' ');
                    for (int j = 0; j < m; j++)
                    {
                        a[i, j] = int.Parse(ss[j]);

                        int target = 0;
                        if (i + 1 < n) target++;
                        if (j + 1 < m) target++;
                        if (i - 1 >= 0) target++;
                        if (j - 1 >= 0) target++;

                        if (a[i, j] > target)
                        {
                            ok = false;
                            break;
                        }

                        a[i, j] = target;
                    }
                }

                if (ok)
                {
                    output.WriteLine("YES");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            output.Write(a[i, j]);
                            if (j < m - 1)
                            {
                                output.Write(' ');
                            }
                        }

                        output.WriteLine();
                    }
                }
                else
                {
                    output.WriteLine("NO");
                }
                output.Flush();
            }
        }
    }
}
