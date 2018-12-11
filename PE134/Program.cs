using System;
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            BigInteger result = 0;

            var limit = 1000000;
            var primes = Helpers.GenerateLongPrimesBySieve(limit + 10);  // 
            primes.Remove(2);
            primes.Remove(3);

            for (var i = 1; primes[i] <= limit; i++)
            {
                long magicNumber = primes[i];
                while (magicNumber % 10 != primes[i - 1] % 10) magicNumber += primes[i];
                while (primes[i - 1] > 10 && magicNumber % 100 != primes[i - 1] % 100) magicNumber += primes[i] * 10;
                while (primes[i - 1] > 100 && magicNumber % 1000 != primes[i - 1] % 1000) magicNumber += primes[i] * 100;
                while (primes[i - 1] > 1000 && magicNumber % 10000 != primes[i - 1] % 10000) magicNumber += primes[i] * 1000;
                while (primes[i - 1] > 10000 && magicNumber % 100000 != primes[i - 1] % 100000) magicNumber += primes[i] * 10000;
                while (primes[i - 1] > 100000 && magicNumber % 1000000 != primes[i - 1] % 1000000) magicNumber += primes[i] * 100000;
                result += magicNumber;
            }


            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
