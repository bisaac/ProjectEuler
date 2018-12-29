using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        private static List<long> primes1mod4;
        private static List<long> primes3mod4;
        private static Dictionary<long, int> knownCounts;

        static void Main(string[] args)
        {
            /*
                f(1328125) = 180
                f(84246500) = f(248431625) = 420

                30875234922 for n<=38000000

                271204031455541300
                271204031455541309
                for n<=10^10 i have 2709499279563106.
                is it correct?
                Unfortunately, it's not.
                You aren't the first one to get this particular result, though.
                Yeah, you're on the right track, but are missing something that a lot of other people missed initially too.

                Look at the definition given for f(N)

                There are 5422629 solutions in total and there is no difference between even and odd N. It's something else

                38000000 is significantly less than 10^11.
                That's the only significance of 38000000.

                Think I just had my epiphany, having to do with the completeness of my 3(mod4) list
             */

            Stopwatch clock = Stopwatch.StartNew();
            BigInteger result = 0;
            var upperLimit = 38000000;

            //Console.WriteLine("Fill the primes list...");
            //primes = Helpers.GeneratePrimeList(upperLimit);
            //Console.WriteLine("Fill the primes list...");
            primes1mod4 = new List<long>();
            primes3mod4 = new List<long>();
            knownCounts = new Dictionary<long, int>();

            for (long N = 1; N <= upperLimit; N++)
            //for (long N = 248431625; N <= 248431625; N++)
            {
                //Console.WriteLine("Diameter: " + N);

                if (f(N) == 105)  // 420 points
                    result += N;

                //result = 4 * (mod1 - mod3);

                //Console.WriteLine($"f(38000000): {f(38000000)}");
                //Console.WriteLine($"f(248431625): {f(248431625)}");

                //result = old_f(N);
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static long f(long N)
        {
            int count = 1;

            while (N % 2 == 0) N /= 2;

            var p = 0;
            while (N > 1 && p < primes3mod4.Count && primes3mod4[p] <= N)
            {
                while (N % primes3mod4[p] == 0)
                    N /= primes3mod4[p];
                p++;
            }

            if (knownCounts.ContainsKey(N)) return knownCounts[N];
            long hold = N;

            p = 0;
            while (N > 1 && p < primes1mod4.Count && primes1mod4[p] <= N)
            {
                var factorCount = 0;
                while (N % primes1mod4[p] == 0)
                {
                    factorCount++;
                    N /= primes1mod4[p];
                }
                count *= 2 * factorCount + 1;

                p++;
            }

            if (N > 1)
            {
                primes1mod4.Add(N);
                count = 3;
            }

            knownCounts.Add(hold, count * 4);

            return 4 * count;
        }

        private static long old_f(long N)
        {
            long count = 0;

            var mod1 = 0;
            var mod3 = 0;

            var diameterSquared = 2 * N * N;
            for (long i = 1; i * i <= diameterSquared; i++)
            {
                if (diameterSquared % i == 0)
                {
                    if (i % 4 == 1 || diameterSquared / i % 4 == 1)
                    {
                        mod1++;
                        //Console.WriteLine(i + " Mod 4 == 1");
                    }

                    if (i % 4 == 3 || diameterSquared / i % 4 == 3)
                    {
                        mod3++;
                        //Console.WriteLine(i + " Mod 4 == 3");
                    }
                }
            }

            //Console.WriteLine("Diameter: {3}, Mod1: {0}, Mod3: {1}, Result: {2}", mod1, mod3, 4 * (mod1 - mod3), N);

            // (420 - 4) / 8 = 104

            count = mod1 - mod3;  // 420 points

            return 4*count;
        }
    }
}
