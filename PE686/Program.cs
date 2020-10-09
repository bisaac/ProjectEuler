using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();

            var startingValue = Math.Log(1.23, 10);
            var endingValue = Math.Log(1.24, 10);
            var log2 = Math.Log(2, 10);

            int desiredNumber = 678910;
            int currentNumber = 0;
            int i = 0;

            while(currentNumber < desiredNumber)
            {
                i++;
                var currentValue = log2 * i;
                currentValue -= Math.Floor(currentValue);

                if (currentValue >= startingValue && currentValue < endingValue)
                {
                    currentNumber++;
                }
            }

            clock.Stop();
            Console.WriteLine($"Answer: {i:0}");
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);

            Console.ReadLine();
        }
    }
}
