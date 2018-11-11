using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            // OEIS A066265		a(n) = number of semiprimes < 10^n.
            // 0, 3, 34, 299, 2625, 23378, 210035, 1904324, 17427258


            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            var topNumber = 100000000;

            Console.WriteLine("Getting primes...");
            var primes = Helpers.GeneratePrimeSieve(topNumber/2);

            for (var i = 1; i <= topNumber / i; i++)
            {
                if (!primes[i]) continue;
                for (var j = i; j <= topNumber / i; j++)
                {
                    if (!primes[j]) continue;
                    result++;
                }
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
