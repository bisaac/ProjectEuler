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

            for (var a = 3; a <= 1000; a++)
            {
                if (a % 2 == 0)
                {
                    result += a * (a - 2);
                }
                else
                {
                    result += a * (a - 1);
                }
            }


            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
