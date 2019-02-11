using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;
            int upperLimit = 4; // 100000000; //

            var primes = Helpers.GenerateIntPrimesBySieve(upperLimit);
            var primeCounts = new int[primes.Count];

            for (var i = 0; i < primes.Count; i++)
            {
                var step = primes[i];
                while (step <= upperLimit)
                {
                    primeCounts[i] += upperLimit / step;
                    step *= primes[i];
                }
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
