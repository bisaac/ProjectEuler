using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Brute force

            Stopwatch clock = Stopwatch.StartNew();
            long result = 2;

            long topNumber = 201820182018;

            var primes = new List<long>();
            primes.Add(2);

            for (long i = 3; i <= topNumber; i++)
            {
                Console.WriteLine(i);
                var pFlag = true;
                for (var p = primes.Count - 1; p >= 0; p--)
                {
                    if (i % primes[p] == 0)
                    {
                        result = (result + primes[p]) % 1000000000;
                        pFlag = false;
                        p = 0;
                    }
                }
                if (pFlag)
                {
                    result = (result + i) % 1000000000;
                    primes.Add(i);
                }
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
