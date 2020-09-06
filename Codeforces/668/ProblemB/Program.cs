using System;
using System.Linq;

namespace ProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int tt = 0; tt < t; tt++)
            {
                int n = int.Parse(Console.ReadLine());

                var lst = Console.ReadLine().Split(' ').Select(s => long.Parse(s)).ToList();

                long total = 0;
                long sumPos = 0;
                foreach (var x in lst)
                {
                    if (x > 0)
                    {
                        sumPos += x;
                    }
                    else
                    {
                        var abs = Math.Abs(x);

                        if (sumPos < abs)
                        {
                            total += (abs - sumPos);
                            sumPos = 0;
                        }
                        else
                        {
                            sumPos -= abs;
                        }
                    }
                }

                Console.WriteLine(total);
            }
        }
    }
}
