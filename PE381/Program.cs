using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        private static int numMax = 100000000;

        static void Main(string[] args)
        {
            long result = 0;
            var primeArray = Helpers.GeneratePrimeSieve(numMax);


            for (int b = 5; b < numMax; b++)
            {
                if (primeArray[b])
                {
                    // var factorial1 = b - 1;
                    // var factorial2 = 1;
                    long factorial3 = (b - 1L) / 2L;

                    //var inverseMultiplier = 0L;
                    //while (((b-3) * inverseMultiplier) % b != 1) inverseMultiplier++;

                    var inverseMultiplier = modInverse(b - 3, b);
                    var factorial4 = (factorial3 * inverseMultiplier) % b;

                    //inverseMultiplier = 0L;
                    //while (((b-4) * inverseMultiplier) % b != 1) inverseMultiplier++;

                    inverseMultiplier = modInverse(b - 4, b);
                    var factorial5 = (factorial4 * inverseMultiplier) % b;

                    var subTotal = (factorial3 + factorial4 + factorial5) % b;

                    result += subTotal;
                }
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static long GetFactorialMod(long num, long mod)
        {
            long factorial = 1;
            for (long b = 2; b <= num; b++)
            {
                factorial = (factorial * b) % mod;
            }

            return factorial;
        }

        private static long modInverse(long a, long m)
        {
            long m0 = m;
            long y = 0;
            long x = 1;

            if (m == 1) return 0;

            while (a > 1)
            {
                // q is quotient
                long q = a / m;
                long t = m;

                // m is remainder now; process same as Euclid's algorithm
                m = a % m;
                a = t;
                t = y;

                // Update y and x
                y = x - q * y;
                x = t;
            }

            // Make x positive
            if (x < 0)
                x += m0;

            return x;
        }
    }
}
