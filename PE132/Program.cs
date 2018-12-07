using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            var primeList = Helpers.GenerateIntPrimesBySieve(300000);

            var primes = 0;
            var i = 0;

            // Wikipedia: repunit
            // - Formula [base b]  R(n) = (b^n - 1)/(b - 1)
            //           [base 10] R(n) = (10^n - 1)/9

            while (primes < 40)
            {
                if (BigInteger.ModPow(10, 1000000000, 9 * primeList[i]) == 1)
                {
                    primes++;
                    result += primeList[i];
                    Console.WriteLine("Prime: {0}", primeList[i]);
                }

                i++;
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}