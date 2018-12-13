using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();

            // Pre-add 2 and 5 since A(n) ignores them
            long result = 7;

            var limit = 100000;
            var primes = Helpers.GenerateIntPrimesBySieve(limit);

            for (var i = 0; i < primes.Count; i++)
            {
                var hold = A(primes[i]);
                if (hold == 0) continue;

                while (hold % 2 == 0) hold /= 2;
                while (hold % 5 == 0) hold /= 5;

                if (hold != 1)
                {
                    //Console.WriteLine("{0} - {1} - {2}", primes[i], A(primes[i]), hold);
                    result += primes[i];
                }
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static int A(int n)
        {
            if (Helpers.Gcd(n, 10) != 1) return 0;

            int k = 1;
            int repUnit = 1;
            while (repUnit != 0)
            {
                repUnit = (10 * repUnit + 1) % n;
                k++;
            }
            return k;
        }
    }
}
