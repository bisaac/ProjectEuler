using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            double result = 0;

            var oneOver2pi = 1.0 / (2.0 * Math.PI);

            var piOver2 = 300 * Math.PI;
            Console.WriteLine(piOver2);

            var yOver30MinusX = 150 * (-3.0 * Math.Log(5.0) + Math.Log(27.0) + 4.0 * Math.Atan2(4.0, 3.0));
            Console.WriteLine(yOver30MinusX);

            var xOver40MinusY = 100 * (Math.PI + 16 * Math.Log(2.0) - 8.0 * Math.Log(5.0) + Math.Atan2(10296.0, 11753.0));
            Console.WriteLine(xOver40MinusY);

            result = oneOver2pi * (piOver2 + yOver30MinusX + xOver40MinusY) / 600.0;  // divide by area

            clock.Stop();
            Console.WriteLine($"Answer: {result:0.##########}");
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
