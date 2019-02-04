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

            BigInteger step = 1;

            for (var i = 1; i <= 31; i++)
            {
                // Find starting place
                if (step % i != 0)
                {
                    BigInteger gcd = Helpers.Gcd(step, i);
                    step *= i / gcd;
                }

                BigInteger maxLimit = BigInteger.Pow(4, i) - 1;
                for (BigInteger n = step; n < maxLimit; n += step)
                {
                    if (n % (i + 1) != 0) result++;
                }
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
