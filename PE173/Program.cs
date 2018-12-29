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
            int upperLimit = 1000000;

            for (long o = (upperLimit / 4) + 1; o >= 3; o--)
                for (long i = o - 2; i >= 1; i -= 2)
                    if (o * o - i * i <= upperLimit) result++;

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
