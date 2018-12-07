using System;
using System.Collections.Generic;
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

            var repUnit = R(1000000000);

            var primes = new List<int>();
            while (primes.Count < 40 && repUnit > 1)
            {

            }


            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static BigInteger R(int k)
        {
            BigInteger repUnit = 1;
            for (var i = 1; i < k; i++)
                repUnit = 10 * repUnit + 1;
            return repUnit;
        }
    }
}