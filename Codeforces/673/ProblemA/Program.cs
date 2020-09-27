using System;
using System.Linq;

namespace ProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for (int t = 0; t < T; t++)
            {
                var parts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int k = parts[1];

                var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                Array.Sort(nums);

                int sum = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    int diff = k - nums[i];

                    sum += diff / nums[0];
                }
             
                Console.WriteLine(sum);
            }
        }
    }
}
