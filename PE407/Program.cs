using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Program
    {
        // EM(101) ---> n = 101 ---> 2549
        // EM(1001) ---> n = 1001 ---> 314034

        // EM(10^5 + 1) = 3717852515
        // EM(10^6 + 1) = 386778427463
        // EM(10^7) = 14 digits

        private static BitArray _primes;

        static void Main(string[] args)
        {
            long result = 0;

            int n = 101;

            _primes = Helpers.GeneratePrimeSieve(n);

            for (int i = 2; i < n; i++)
            {
                result += M(i);
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static long M(int n)
        {
            if (_primes[n]) return 1;

            var poweredPrimes = Helpers.GetPoweredPrimeFactors(n, _primes);
            if (poweredPrimes.Count == 1) return 1;

            long largest = 0;
            //for (long j = 1; j < n; j++)
            //{
            //    if ((j * j) % n == j && largest < j) largest = j;
            //}

            foreach (var pp in poweredPrimes)
            {
                var u = pp.Value;
                int v = n / u;
                var w = Helpers.ModularMultiplicativeInverse(u, v) % v;
                if (largest < u * w) largest = u * w;
            }

            Console.WriteLine(n + " ---> " + largest);
            return largest;
        }
    }
}
