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

            var limit = 1000001;
            var n = limit;

            while (A(n) < limit) n += 2;

            result = n;

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static long R(int k)
        {
            long result = 1;
            for (var i = 1; i < k; i++) result = (result * 10) + 1;
            return result;
        }

        private static int A(int n)
        {
            if (Gcd(n, 10) != 1) return 0;

            int k = 1;
            int repUnit = 1;
            while (repUnit != 0)
            {
                repUnit = (10 * repUnit + 1) % n;
                k++;
            }
            return k;
        }

        private static int Gcd(int x, int y)
        {
            return y == 0 ? x : Gcd(y, x % y);
        }
    }
}
