using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemC
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.In;
            var output = Console.Out;

            int t = int.Parse(input.ReadLine());

            for (int tt = 0; tt < t; tt++)
            {
                int n = int.Parse(input.ReadLine());

                var a = input.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var lastPosition = new Dictionary<int, int>();
                var worstLength = new Dictionary<int, int>();
                var bestNumberForLength = new Dictionary<int, int>();

                for (int i = 0; i < n; i++)
                {
                    if (!lastPosition.ContainsKey(a[i]))
                    {
                        var newLen = Math.Max(i + 1, n - i);
                        worstLength.Add(a[i], i + 1);
                        UpdateBestNumberForLength(bestNumberForLength, newLen, a[i]);
                        lastPosition.Add(a[i], i);
                    }
                    else
                    {
                        var prevPos = lastPosition[a[i]];
                        var prevMax = worstLength[a[i]];
                        var newLen = Math.Max(i - prevPos, n - i);
                        var newMax = Math.Max(prevMax, i - prevPos);
                        worstLength[a[i]] = newMax;
                        UpdateBestNumberForLength(bestNumberForLength, Math.Max(prevMax, newLen), a[i]);
                        lastPosition[a[i]] = i;
                    }
                }

                var result = new List<int>();
                int min = Int32.MaxValue;
                
                for (int i = 1; i <= n; i++)
                {
                    int number;
                    if (bestNumberForLength.TryGetValue(i, out number))
                    {
                        if (number < min)
                        {
                            min = number;
                        }

                        result.Add(Math.Min(number, min));
                    }
                    else
                    {
                        if (min != Int32.MaxValue)
                        {
                            result.Add(min);
                        }
                        else
                        {
                            result.Add(-1);
                        }
                    }
                }

                output.WriteLine(string.Join(" ", result));
            }
        }

        private static void UpdateBestNumberForLength(Dictionary<int, int> dict, int len, int number)
        {
            if (!dict.ContainsKey(len))
            {
                dict.Add(len, number);
            }
            else
            {
                dict[len] = Math.Min(dict[len], number);
            }
        }
    }
}
