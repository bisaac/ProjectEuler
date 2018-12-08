using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            // See notes - involved variable substitution

            var limit = 1000000;
            var nValues = new int[limit + 1];

            for (int i = 1; i < limit; i++)
            {
                for (var j = 1; i * j < limit; j++)
                {
                    if ((i + j) % 4 == 0 && 3 * j > i && ((3 * j - i) % 4) == 0)
                    {
                        nValues[i * j]++;
                    }
                }
            }

            result = nValues.Where(x => x == 10).Count();

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
