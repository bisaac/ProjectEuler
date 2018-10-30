using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            double smallestChange = 0.00000000001;

            int n = 0;
            double delta = 1;
            while (delta > smallestChange)
            {
                delta = 1.0 - Math.Pow(1 - Math.Pow(0.5, n), 32);
                result += delta;
                Console.WriteLine(result);
                n++;
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
