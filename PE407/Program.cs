using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        // EM(100) ---> n = 100 ---> 2549
        // EM(1000) ---> n = 1000 ---> 314034

        // EM(10^5) = 3717852515
        // EM(10^6) = 386778427463
        // EM(10^7) = 14 digits

        private static BitArray _primes;
        private static List<long>[] _primeFactors;

        static void Main(string[] args)
        {
            long result = 0;

            int n = 10000000;

            Console.WriteLine("Getting primes...");
            _primes = Helpers.GeneratePrimeSieve(n);

            Console.WriteLine("Getting prime factor lists...");
            _primeFactors = Helpers.GetPrimeFactorLists(n, _primes);

            for (int i = 2; i <= n; i++)
            {
                result += M(i);
            }

            //var largest = Helpers.GetLargestPrimeFactors(n);

            //result = _primeFactors.Length;

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static long M(int n)
        {
            if (_primes[n]) return 1;

            var lp = _primeFactors[n].Max();
            long start = n;
            while (start % lp == 0) start /= lp;
            if (start == 1) return 1;

            start = n - (n % lp);
            for (long x = start; x >= lp; x -= lp)
            {
                var xp1 = x + 1;
                if ((xp1 * xp1) % n == xp1) return xp1;

                if ((x * x) % n == x) return x;
            }

            return 1;
        }
    }
}
