using System;

namespace RoundingExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new double[] {0.2, 0.5, 0.7, 1.5, 2.5, 3.5, 4.49, 4.5, 4.51, 5.5, 6.5, 7.5, 8.5};

            foreach(var value in values)
                Console.WriteLine($"{value,-5} : {Math.Round(value,0)}");
            Console.WriteLine();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
