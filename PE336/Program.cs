using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            string result = String.Empty;

            Dictionary<string, int> combinations = new Dictionary<string, int>();
            combinations.Add("ABCD", 0);
            var spins = 0;

            while (true)
            {
                var currentCombos = combinations.Where(x => x.Value == spins).ToList();
                if (currentCombos.Count == 0) break;
                foreach (var combo in currentCombos)
                {
                    for (var i = 2; i <= combo.Key.Length; i++)
                    {
                        var newCombo = RotateStringEnd(combo.Key, i);
                        //if (newCombo == "DFAECB") Console.WriteLine("DFAECB ==> " + spins + 1);
                        if (!combinations.ContainsKey(newCombo)) combinations.Add(newCombo, spins + 1);
                    }
                }

                spins++;
            }

            var topCombos = combinations.Where(x => x.Value == spins - 1).Select(x => x.Key).ToList();
            topCombos.Sort();

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static string RotateStringEnd(string start, int numLetters)
        {
            var sb = new StringBuilder();

            if (numLetters < start.Length)
            {
                sb.Append(start.Substring(0, start.Length - numLetters));
            }

            for (var i = 1; i <= numLetters; i++)
            {
                sb.Append(start[start.Length - i]);
            }

            return sb.ToString();
        }
    }
}
