using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        private static long upperLimit = 1000000000000;
        private static long mask = (long)Math.Pow(2, 32);
        private static BigInteger result = 0;
        private static List<long> primes;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();

            var hamming = new List<long>();

            long baseTwo = 1;
            while (baseTwo < upperLimit)
            {
                long baseThree = 1;
                while (baseTwo * baseThree <= upperLimit)
                {
                    long baseFive = 1;
                    while (baseTwo * baseThree * baseFive <= upperLimit)
                    {
                        hamming.Add(baseTwo * baseThree * baseFive);
                        baseFive *= 5;
                    }
                    baseThree *= 3;
                }
                baseTwo *= 2;
            }

            primes = new List<long>();
            for (var i = 0; i < hamming.Count; i++)
            {
                if (IsPrime(hamming[i] + 1))
                {
                    primes.Add(hamming[i] + 1);
                }
            }
            primes.Sort();

            AddPrimeMultiples(1, 0);

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static void AddPrimeMultiples(BigInteger current, int lastprime)
        {
            if (current > upperLimit) return;

            result = (result + current) % mask;

            // Check for 2, 3, and 5
            var startPrime = lastprime;
            if (lastprime > 2) startPrime++;

            for (var i = startPrime; i < primes.Count() && current * primes[i] <= upperLimit; i++)
            {
                AddPrimeMultiples(current * primes[i], i);
            }
        }

        private static bool IsPrime(long n)
        {
            if (n < 2)
                return false;
            if (n < 4)
                return true;
            if (n % 2 == 0)
                return false;
            if (n < 9)
                return true;
            if (n % 3 == 0)
                return false;
            if (n < 25)
                return true;

            int s = (int)Math.Sqrt(n);
            for (int i = 5; i <= s; i += 6)
            {
                if (n % i == 0)
                    return false;
                if (n % (i + 2) == 0)
                    return false;
            }

            return true;
        }
    }
}
