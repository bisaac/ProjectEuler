using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();

            var startingValue = (decimal)Math.Log(123, 2);
            var endingValue = (decimal)Math.Log(124, 2);
            var log10 = (decimal)Math.Log(10, 2);

            int desiredNumber = 45; // 678910;
            int currentNumber = 0;

            while(currentNumber < desiredNumber)
            {
                startingValue += log10;
                endingValue += log10;

                var floorStart = Math.Floor(startingValue);
                var floorEnd = Math.Floor(endingValue);

                // Console.WriteLine($"Start: {floorEnd:0}   End: {floorEnd:0}  CurrentNumber: {currentNumber}");

                if (floorEnd > floorStart)
                {
                    currentNumber++;
                    // Console.WriteLine($"Start: {floorStart:0}   End: {floorEnd:0}  CurrentNumber: {currentNumber}");
                    if (currentNumber == desiredNumber)
                    {
                        clock.Stop();
                        Console.WriteLine($"Answer: {floorEnd:0}");
                        Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
