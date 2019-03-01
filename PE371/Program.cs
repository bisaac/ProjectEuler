using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            double result = 0;

            int plates = 1000;

            double probZero = 1.0 / plates;
            double prob500 = 1.0 / plates;

            double[] no500 = new double[501];
            double[] seen500 = new double[501];
            no500[500] = 0.0;
            seen500[500] = 0.0;

            for (var seen = 499; seen >= 0; seen--)
            {
                double numUnseen = plates - 2.0 * seen - 2;
                double probUnseen = numUnseen / plates;

                double probSeen = (double)seen / plates;

                seen500[seen] = (1 + probUnseen * seen500[seen + 1]                          ) / (1 - (probZero + probSeen));
                no500[seen]   = (1 + probUnseen * no500[seen + 1]   + prob500 * seen500[seen]) / (1 - (probZero + probSeen));
            }

            result = no500[0];

            clock.Stop();
            Console.WriteLine($"Answer: {result:###.########}");
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
