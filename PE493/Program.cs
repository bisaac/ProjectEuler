using System;

namespace PE493
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0.0;

            result = 7.0 * (1.0 - (50.0 * 49.0 * 48.0 * 47.0 * 46.0 * 45.0 * 44.0 * 43.0 * 42.0 * 41.0) /
                     (70.0 * 69.0 * 68.0 * 67.0 * 66.0 * 65.0 * 64.0 * 63.0 * 62.0 * 61.0));

            Console.WriteLine("Answer: " + result);
            //Console.ReadLine();
        }
    }
}
