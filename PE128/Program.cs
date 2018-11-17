using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            // Preload n = 1, 2, and 8
            int found = 3;
            int needed = 2000;

            long layer = 2;
            while (found < needed)
            {

                // check "end" of ring
                long endValue = 6 * layer * (layer + 1) / 2 + 1;
                //if (primes[6 * (layer + 2) * (layer + 1) / 2 - endValue] && primes[endValue - (6 * layer * (layer - 1) / 2 + 2)] && primes[endValue - (6 * (layer - 1) * (layer - 2) / 2 + 2)])
                if (IsPrime(6 * (layer + 2) * (layer + 1) / 2 - endValue) && IsPrime(endValue - (6 * layer * (layer - 1) / 2 + 2)) && IsPrime(endValue - (6 * (layer - 1) * (layer - 2) / 2 + 2)))
                {
                    found++;
                    //Console.WriteLine("{4}-{0} ==> {1},{2},{3}", endValue, 6 * (layer + 2) * (layer + 1) / 2, 6 * layer * (layer - 1) / 2 + 2, 6 * (layer - 1) * (layer - 2) / 2 + 2, found);
                    result = endValue;
                    if (found == needed) break;
                }

                // check "start" of next ring
                long startValue = endValue + 1;
                // if (found != needed && primes[6 * (layer + 2) * (layer + 1) / 2 + 1 - startValue] && primes[6 * (layer + 2) * (layer + 1) / 2 + 3 - startValue] && primes[6 * (layer + 2) * (layer + 3) / 2 + 1 - startValue])
                if (IsPrime(6 * (layer + 2) * (layer + 1) / 2 + 1 - startValue) && IsPrime(6 * (layer + 2) * (layer + 1) / 2 + 3 - startValue) && IsPrime(6 * (layer + 2) * (layer + 3) / 2 + 1 - startValue))
                {
                    found++;
                    //Console.WriteLine("{4}-{0} ==> {1},{2},{3}", startValue, 6 * (layer + 2) * (layer + 1) / 2 + 1, 6 * (layer + 2) * (layer + 1) / 2 + 3, 6 * (layer + 2) * (layer + 3) / 2 + 1,found);
                    result = startValue;
                }

                layer++;
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        public static bool IsPrime(long n)
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
