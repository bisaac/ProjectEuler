using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        private static long[,] values;

        private static List<int> primes;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            int finalTerm = 24;
            int mask = (int)Math.Pow(10, 9);

            var term = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368 };

            primes = Helpers.GenerateIntPrimesBySieve(term[finalTerm] + 1);
            primes.Insert(0, 0);

            values = new long[term[finalTerm] + 1, primes.Count];

            // Fill zero column so primes are added appropriately
            for (int j = 0; j < primes.Count; values[0, j++] = 1);

            for (var k = 2; k <= term[finalTerm]; k++)
            {
                for (var j = 1; j < primes.Count; j++)
                {
                    if (primes[j] <= k)
                    {
                        values[k, j] = (values[k, j - 1] + primes[j] * values[k - primes[j], j]) % mask;
                    }
                    else
                    {
                        values[k, j] = values[k, j - 1];
                    }
                }
            }

            for (var f = 2; f <= finalTerm; f++)
            {
                Console.WriteLine($"{f,5} : {term[f],5} : {values[term[f], primes.Count - 1], 10}");
                result = (result + values[term[f], primes.Count - 1]) % mask;
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
