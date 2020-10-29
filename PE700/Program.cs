using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        private static ulong step = 1504170715041707;
        private static ulong modMask = 4503599627370517;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            ulong result = 0;

            ulong currentNumber = 1504170715041707;

            while (currentNumber > 0)
            {
                result += currentNumber;
                Console.WriteLine($"{currentNumber}  {result}");

                if (currentNumber < modMask)
                {
                    modMask %= currentNumber;
                }

                currentNumber -= modMask;
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
