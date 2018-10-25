using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace PE387
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            long answer = 0;
            var odds = new List<long> {1, 3, 7, 9};
            var harshad = new List<long> {1,2,3,4,5,6,7,8,9};

            for (var size = 1; size < 13; size++)
            {
                var size1 = size;
                var nextSet = harshad.Where(n => n >= Math.Pow(10, size1 - 1) && n < Math.Pow(10, size1)).ToList();

                foreach (var num in nextSet)
                {
                    for (var digit = 0; digit < 10; digit++)
                    {
                        var n = num * 10 + digit;
                        var s = SumOfDigits(n);

                        if ((n % s) != 0) continue;
                        harshad.Add(n);
                    }
                }
            }

            var primes = new List<long>();
            foreach (var h in harshad)
            {
                if (!IsPrime(h / SumOfDigits(h))) continue;

                primes.Add(h);
            }

            foreach (var p in primes)
            {
                foreach (var o in odds)
                {
                    var num = p * 10 + o;
                    if (!IsPrime(num)) continue;
                    answer += num;
                }
            }

            Console.WriteLine("Answer: " + answer);
            Console.ReadLine();
        }

        private static long SumOfDigits(long number)
        {
            long sum = 0;

            while (number > 0)
            {
                sum += (number % 10);
                number /= 10;
            }

            return sum;
        }

        private static bool IsPrime(long number)
        {
            if (number == 1) return false;

            for (var i = (long) Math.Sqrt(number); i > 1; i--)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
