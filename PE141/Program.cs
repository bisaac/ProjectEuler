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
            long upperLimit = 1000000000000;

            for (long x = 2; x * x * x <= upperLimit; x++)
                for (long y = 1; y < x; y++)
                {
                    if (y * x * x * x + y * y > upperLimit) break;

                    // Make sure the fraction x/y cannot be reduced
                    if (Helpers.Gcd(x, y) > 1) continue;

                    for (long z = 1; ; z++)
                    {
                        long n = z * z * y * x * x * x + z * y * y;
                        if (n > upperLimit) break;
                        if (IsSquare(n))
                            result += n;
                    }
                }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static bool IsSquare(long n)
        {
            var s = (long)Math.Sqrt(n);
            return s * s == n;
        }
    }
}
