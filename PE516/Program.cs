using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        private static long upperLimit = 100; //1000000000000;
        private static long result = 0;
        private static List<long> primes;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            //long result = 0;

            var hamming = new List<long>();
            //var upperLimit = 1000000000000;

            long baseTwo = 1;
            while (baseTwo < upperLimit)
            {
                long baseThree = 1;
                while (baseTwo * baseThree <= upperLimit)
                {
                    long baseFive = 1;
                    while (baseTwo * baseThree * baseFive <= upperLimit)
                    {
                        hamming.Add(baseTwo * baseThree * baseFive);
                        baseFive *= 5;
                    }
                    baseThree *= 3;
                }
                baseTwo *= 2;
            }

            //result = hamming.Count;

            //hamming.Sort();
            primes = new List<long>();
            for (var i = 0; i < hamming.Count; i++)
            {
                if (IsPrime(i + 1))
                {
                    primes.Add(i + 1);
                    //result += i;
                }
            }
            //result = primes.Count;

            for (var d = 1; d < 100; d++)
                if (hamming.Contains(Totient(d))) Console.WriteLine($"\t{d}");

            AddPrimeMultiples(1, 2);

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static void AddPrimeMultiples(long current, long lastprime)
        {
            if (current >= upperLimit) return;

            Console.WriteLine(current);

            result += current;

            foreach (var p in primes.Where(pr => pr >= lastprime))
            {
                AddPrimeMultiples(current * p, p);
            }
        }

        private static bool IsPrime(long n)
        {
            if (n < 2)
                return false;
            if (n < 4)
                return true;
            if (n % 2 == 0)
                return false;
            if (n < 9)
                return true;
            if (n % 3 == 0)
                return false;
            if (n < 25)
                return true;

            int s = (int)Math.Sqrt(n);
            for (int i = 5; i <= s; i += 6)
            {
                if (n % i == 0)
                    return false;
                if (n % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        private static int Totient(int number)
        {
            if (IsPrime(number)) return number - 1;

            double product = 1;

            int holdValue = number;
            int index = 2;
            while (holdValue > 1)
            {
                while (!IsPrime(index)) index++;

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
