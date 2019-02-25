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
            float result = 0;

            var totalPlates = 0;
            var totalWins = 0;

            var previous = new List<int>();
            var plateMaker = new Random();

            for (var i = 0; i < 100000000; i++)
            {
                var plates = 0;
                previous.Clear();
                var found = false;

                do
                {
                    var nextPlate = plateMaker.Next(1000);
                    plates += 1;
                    found = previous.Contains(1000 - nextPlate);
                    if (!previous.Contains(nextPlate)) previous.Add(nextPlate);
                } while (!found);

                totalPlates += plates;
                totalWins++;

                Console.WriteLine((float)totalPlates / totalWins);
            }


            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
