using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            BigInteger result = 1;
            int modValue = 1000000009;
            
            int upperLimit = 100000000;

            var primes = Helpers.GenerateLongPrimesBySieve(upperLimit);

            for (var i = 0; i < primes.Count; i++)
            {
                long count = 0;
                long step = primes[i];
                while (step <= upperLimit)
                {
                    count += upperLimit / step;
                    step *= primes[i];
                }

                result = result * (BigInteger.ModPow(new BigInteger(primes[i]), 2 * count, modValue) + 1) % modValue;
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
