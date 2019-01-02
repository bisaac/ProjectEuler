using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        private static List<int>[] values;

        private static List<int> primes;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;
            int finalTerm = 24;

            var term = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368 };

            // primes = new List<int>();
            primes = Helpers.GenerateIntPrimesBySieve(term[finalTerm]);
            values = new List<int>[46369];
            values[1] = new List<int>();

            //for (int i = 2; i <= term[finalTerm]; i++)
            for (int i = 2; i <= finalTerm; i++)
            {
                //if (Helpers.IsPrime(i))
                //{
                //    primes.Add(i);
                //    values[i] = new List<int> {i};
                //}

                // FindEntries(i);
                Console.WriteLine($"{i,-8} : {term[i]}");
                FindEntries(term[i], 0, 0, 1);
            }

            //result = term.Length;
            for (var i = 2; i <= finalTerm; i++)
                result += values[term[i]].Sum() % 1000000;

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static void FindEntries(int value)
        {
            if (values[value] == null) values[value] = new List<int>();

            for (var p = 0; p < primes.Count && primes[p] < value; p++)
            {
                var diff = value - primes[p];
                foreach (var product in values[diff])
                {
                    var currentProduct = (product * primes[p]) % 1000000;
                    if (!values[value].Contains(currentProduct)) values[value].Add(currentProduct);
                }
            }
        }

        private static void FindEntries(int totalSum, int startingPrime, int currentSum, int currentProduct)
        {
            if (totalSum == currentSum)
            {
                if (values[totalSum] == null) values[totalSum] = new List<int>();
                if (!values[totalSum].Contains(currentProduct)) values[totalSum].Add(currentProduct);
            }
            else
            {
                for (var t = startingPrime; t < primes.Count && primes[t] <= totalSum - currentSum; t++)
                {
                    FindEntries(totalSum, t, currentSum + primes[t], (currentProduct * primes[t]) % 1000000000);
                }
            }
        }
    }
}
