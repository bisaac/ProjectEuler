using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            long upperBound = 1000000;

            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            for (long i = 4; i <= upperBound; i++)
            {
                var squared = i * i;
                if (IsSNumber(i, squared))
                    result += squared;
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        static bool IsSNumber(long numberSum, long numberToUse)
        {
            if (numberSum > numberToUse) return false;
            if (numberSum == numberToUse) return true;

            long divisor = 10;
            while (divisor < numberToUse)
            {
                var q = numberToUse / divisor;
                var r = numberToUse % divisor;

                if (r < numberSum && IsSNumber(numberSum - r, q)) return true;

                divisor *= 10;
            }

            return false;
        }
    }
}
