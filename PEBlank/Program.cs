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
            long result = 0;

            for (int i = 1; i < 100; i += 2)
            {
                if (Gcd(i, 10) != 1) continue;
                Console.WriteLine("{0} - {1}", i, BuildRepUnit(i));
            }

            result = BuildRepUnit(41);

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static int BuildRepUnit(int divisor)
        {
            int size = 1;
            BigInteger repUnit = 1;
            while (repUnit % divisor != 0)
            {
                size++;
                repUnit = (10 * repUnit) + 1;
            }
            return size;
        }

        private static int Gcd(int x, int y)
        {
            return y == 0 ? x : Gcd(y, x % y);
        }
    }
}
