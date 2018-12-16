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
            long result = 0;
            int limit = 124;
            var nonDivisors = new List<int> { 27 };

            var i = 27;

            while (nonDivisors.Count < limit)
            {
                i += 2;
                var term1 = 1;
                var term2 = 1;
                var term3 = 1;

                var determined = false;
                while (!determined)
                {
                    var newTerm = (term1 + term2 + term3) % i;
                    if (newTerm == 0)
                    {
                        // Found divisor
                        determined = true;
                    }
                    if (term2 == 1 && term3 == 1 && newTerm == 1)
                    {
                        // found a loop - doesn't divide
                        nonDivisors.Add(i);
                        determined = true;
                    }
                    term1 = term2;
                    term2 = term3;
                    term3 = newTerm;
                }
            }

            result = nonDivisors[limit - 1];

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
