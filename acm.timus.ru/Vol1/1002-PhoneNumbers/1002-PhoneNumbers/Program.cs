using System;
using System.Collections.Generic;

namespace _1002_PhoneNumbers
{
    /// <summary>
    /// https://acm.timus.ru/problem.aspx?space=1&num=1002
    /// </summary>
    class Program
    {
        private static readonly Dictionary<char, char> DigitMap = new Dictionary<char, char>();

        static void Main(string[] args)
        {
            InitDigitMap();

            string inputNumber = Console.ReadLine();
            while (inputNumber != "-1")
            {
                int numLen = inputNumber.Length;
                int nWords = Convert.ToInt32(Console.ReadLine());

                var words = new string[nWords];
                var digitWords = new string[50000];

                var graph = new int[numLen + 1, numLen + 1];
                for (int i = 0; i < numLen + 1; i++)
                {
                    for (int j = 0; j < numLen + 1; j++)
                    {
                        graph[i, j] = -1;
                    }
                }

                // length -> (digitword -> wordIndex)
                var digitWordsByLength = new Dictionary<int, SortedList<string, int>>();

                for (int i = 0; i < nWords; i++)
                {
                    string w = Console.ReadLine();
                    words[i] = w;
                    string dw = WordToDigits(w);
                    digitWords[i] = dw;

                    int len = dw.Length;
                    if (!digitWordsByLength.ContainsKey(len))
                    {
                        digitWordsByLength.Add(len, new SortedList<string, int>());
                    }

                    try
                    {
                        digitWordsByLength[len].Add(dw, i);
                    }
                    catch (ArgumentException)
                    {
                        // do nothing
                    }
                }

                for (int i = 0; i < numLen; i++)
                {
                    for (int j = i; j < numLen; j++)
                    {
                        string pat = inputNumber.Substring(i, j - i + 1);

                        SortedList<string, int> wordsToSearch;
                        if (digitWordsByLength.TryGetValue(pat.Length, out wordsToSearch))
                        {
                            int wordIndex;
                            if (wordsToSearch.TryGetValue(pat, out wordIndex))
                            {
                                graph[i, j + 1] = wordIndex;
                            }
                        }
                    }
                }

                var dist = new int[numLen + 1];
                for (int i = 0; i < numLen + 1; i++) dist[i] = 0;

                var prev = new int[numLen + 1];
                for (int i = 0; i < numLen + 1; i++) prev[i] = -1;

                var q = new Queue<int>();
                q.Enqueue(0);

                while (q.Count != 0)
                {
                    int u = q.Dequeue();

                    for (int i = u + 1; i < numLen + 1; i++)
                    {
                        if (graph[u, i] != -1)
                        {
                            if (dist[i] == 0)
                            {
                                dist[i] = dist[u] + 1;
                                prev[i] = u;
                                q.Enqueue(i);
                            }
                        }
                    }
                }

                int cur = numLen;
                int p = prev[cur];
                if (p != -1)
                {
                    var path = new List<string>();

                    while (cur != 0)
                    {
                        int pathWordIndex = graph[p, cur];
                        string pathWord = words[pathWordIndex];
                        path.Add(pathWord);

                        cur = p;
                        p = prev[cur];
                    }

                    path.Reverse();
                    var solution = string.Join(" ", path.ToArray());
                    Console.WriteLine(solution);
                }
                else
                {
                    Console.WriteLine("No solution.");
                }

                inputNumber = Console.ReadLine();
            }
        }

        private static string WordToDigits(string word)
        {
            var result = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                result[i] = DigitMap[word[i]];
            }

            return new string(result);
        }

        private static void InitDigitMap()
        {
            /*
                1 ij    2 abc   3 def
                4 gh    5 kl    6 mn
                7 prs   8 tuv   9 wxy
                        0 oqz 
             */
            DigitMap.Add('a', '2');
            DigitMap.Add('b', '2');
            DigitMap.Add('c', '2');
            DigitMap.Add('d', '3');
            DigitMap.Add('e', '3');
            DigitMap.Add('f', '3');
            DigitMap.Add('g', '4');
            DigitMap.Add('h', '4');
            DigitMap.Add('i', '1');
            DigitMap.Add('j', '1');
            DigitMap.Add('k', '5');
            DigitMap.Add('l', '5');
            DigitMap.Add('m', '6');
            DigitMap.Add('n', '6');
            DigitMap.Add('o', '0');
            DigitMap.Add('p', '7');
            DigitMap.Add('q', '0');
            DigitMap.Add('r', '7');
            DigitMap.Add('s', '7');
            DigitMap.Add('t', '8');
            DigitMap.Add('u', '8');
            DigitMap.Add('v', '8');
            DigitMap.Add('w', '9');
            DigitMap.Add('x', '9');
            DigitMap.Add('y', '9');
            DigitMap.Add('z', '0');
        }
    }

}
