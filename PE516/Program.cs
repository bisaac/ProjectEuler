using System;
using System.Collections.Generic;
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

            //var hamming = new List<long>();

            //for (var two = 0; two < 7; two++)
            //for (var three = 0; three < 5; three++)
            //for (var five = 0; five < 3; five++)
            //{
            //    long value = (long)(Math.Pow(2, two) * Math.Pow(3, three) * Math.Pow(5, five));
            //    if (value < 100) hamming.Add(value);
            //}

            //hamming.Sort();
            //for (var i = 0; i < hamming.Count; i++) Console.WriteLine(hamming[i]);
            //result = hamming.Count;

            for (var d = 1; d <= 100; d++)
                Console.WriteLine($"{d,3} : {Totient(d),4}");

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        public static int Totient(int number)
        {
            if (Helpers.IsPrime(number)) return number - 1;

            double product = 1;

            int holdValue = number;
            int index = 2;
            while (holdValue > 1)
            {
                while (!Helpers.IsPrime(index)) index++;

                if (holdValue % index == 0)
                {
                    product *= (1.0 - (1.0 / index));
                }

                while (holdValue % index == 0) holdValue /= index;

                index++;
            }

            return Convert.ToInt32(product * number);
        }
    }
}
