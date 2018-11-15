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

            var sizes = new int[1001, 1001, 1001];

            for (var x = 1; x <= 1000; x++)
                for (var y = x; y <= 1000 / x; y++)
                for (var z = y; z <= 1000 / (x * y); z++)
                {
                    sizes[x, y, z] = x * y * z;
                    result++;
                }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
