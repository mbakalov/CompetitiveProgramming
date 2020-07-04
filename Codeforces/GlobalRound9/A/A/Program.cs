using System;
using System.Linq;

namespace A
{
    /// <summary>
    /// https://codeforces.com/contest/1375/problem/A
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());

                int[] a = Console.ReadLine().Split(' ').Select(int.Parse).Select(Math.Abs).ToArray();

                for (int j = 0; j < a.Length; j++)
                {
                    if (j % 2 != 0) a[j] = -a[j];
                }

                Console.WriteLine(string.Join(" ", a.Select(x => x.ToString())));
            }
        }
    }
}
