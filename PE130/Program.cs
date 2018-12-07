using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            double result = 0;

            var found = 0;
            var testNumber = 81;
            while (found < 25)
            {
                testNumber += 2;
                if (Helpers.IsPrime(testNumber)) continue;
                var a = A(testNumber);
                if (a != 0 && (testNumber - 1) % a == 0)
                {
                    found++;
                    result += testNumber;
                    Console.WriteLine("({3}) n: {0}, n-1: {1}, A(n): {2}", testNumber, testNumber - 1, a, found);
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
