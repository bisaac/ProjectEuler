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
            uint result = 0;

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

            for (uint d = 1; d <= 100; d++)
            {
                Console.Write($"{d,3} : ");
                var totient = Totient(d);
                Console.Write($"{totient,4}");
                while (totient % 2 == 0) totient /= 2;
                while (totient % 3 == 0) totient /= 3;
                while (totient % 5 == 0) totient /= 5;
                if (totient == 1)
                {
                    Console.Write($"  true");
                    result = (result + d);
                }
                Console.WriteLine();
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        public static uint Totient(uint number)
        {
            if (Helpers.IsPrime(number)) return number - 1;

            double product = 1;

            ulong holdValue = number;
            ulong index = 2;
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

            return Convert.ToUInt32(product * number);
        }
    }
}
