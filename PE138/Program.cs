using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            // rewrite formula for triangle; plug in to Generic two integer variable equation solver (https://www.alpertron.com.ar/QUAD.HTM)

            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            long x = 0;
            long y = -1;

            for (int i = 0; i < 12; i++)
            {
                long xnew = -9 * x + -4 * y + 4;
                long ynew = -20 * x + -9 * y + 8;

                x = xnew;
                y = ynew;

                result += Math.Abs(y);
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
