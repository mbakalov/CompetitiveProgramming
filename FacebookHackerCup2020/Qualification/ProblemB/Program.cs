using System;
using System.IO;
using System.Linq;

namespace ProblemB
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

                var s = input.ReadLine();

                int @as = s.Count(x => x == 'A');
                int @bs = s.Count(x => x == 'B');

                output.WriteLine($"Case #{t + 1}: {(Math.Abs(@as - @bs) == 1 ? 'Y' : 'N')}");
            }

            input.Close();
            output.Close();
        }
    }
}
