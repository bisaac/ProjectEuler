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
            int upperLimit = 100000000;

            var primes = Helpers.GeneratePrimeSieve(upperLimit);

            for (var x = 2; x * x <= upperLimit; x++)
                for (var y = 1; y < x; y++)
                {
                    // Make sure the fraction x/y cannot be reduced
                    if (Helpers.Gcd(x, y) > 1) continue;

                    for (var z = 1; z*x*x <= upperLimit; z++)
                    {
                        if (primes[z * y * y - 1] && primes[z * y * x - 1] && primes[z * x * x - 1])
                        {
                            result += z * y * y + z * y * x + z * x * x - 3;
                        }
                    }
                }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
