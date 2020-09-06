using System;

namespace ProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int tt = 0; tt < t; tt++)
            {
                int n = int.Parse(Console.ReadLine());

                var parts = Console.ReadLine().Split(' ');

                Array.Reverse(parts);
                Console.WriteLine(string.Join(" ", parts));
            }
        }
    }
}
