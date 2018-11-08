using System;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger result = 1;

            var primes = Helpers.GenerateIntPrimesBySieve(10000);

            var numberToExceed = 1000;
            var workingValue = Convert.ToInt32(Math.Pow(Math.Ceiling(Math.Sqrt((numberToExceed) * 2 - 1)), 2));

            var list = Helpers.GetPrimeFactors(workingValue);
            list.Reverse();

            for (int i = 0; i < list.Count; i++)
            {
                result *= BigInteger.Pow(primes[i], (list[i] - 1) / 2);
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
