using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int tt = 0; tt < t; tt++)
            {
                var parts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int n = parts[0];
                int T = parts[1];

                var a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                byte[] color = new byte[a.Length];

                var whiteCount = new Dictionary<int, int>();
                var blackCount = new Dictionary<int, int>();

                whiteCount.Add(a[0], 1);
                color[0] = 0;

                for (int i = 1; i < n; i++)
                {
                    int whiteBad;
                    bool haveWhite = whiteCount.TryGetValue(T - a[i], out whiteBad);

                    int blackBad;
                    bool haveBlack = blackCount.TryGetValue(T - a[i], out blackBad);


                    if (!haveWhite)
                    {
                        AddTo(whiteCount, a[i]);
                        color[i] = 0;
                        continue;
                    }

                    if (!haveBlack)
                    {
                        AddTo(blackCount, a[i]);
                        color[i] = 1;
                        continue;
                    }

                    if (whiteBad < blackBad)
                    {
                        AddTo(whiteCount, a[i]);
                        color[i] = 0;
                    }
                    else
                    {
                        AddTo(blackCount, a[i]);
                        color[i] = 1;
                    }
                }

                Console.WriteLine(string.Join(" ", color));
            }
        }

        private static void AddTo(Dictionary<int, int> dict, int num)
        {
            if (!dict.ContainsKey(num))
            {
                dict.Add(num, 1);
            }
            else
            {
                dict[num]++;
            }
        }
            
    }
}
