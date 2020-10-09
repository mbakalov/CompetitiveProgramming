using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            while (--t >= 0)
            {
                int[] a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                Array.Sort(a);

                Console.WriteLine(a[2] + 1);
            }
        }
    }
}
