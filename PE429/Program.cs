using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        private static List<BigInteger> squares = new List<BigInteger>();
        private static BigInteger result = 0;
        private static int modValue = 1000000009;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            
            int upperLimit = 100000000; // 4; //

            var primes = Helpers.GenerateLongPrimesBySieve(upperLimit);
            Console.WriteLine($"Primes  : {primes.Count}");
            //var primeCounts = new int[primes.Count];

            for (var i = 0; i < primes.Count; i++)
            {
                long count = 0;
                long step = primes[i];
                while (step <= upperLimit)
                {
                    //primeCounts[i] += upperLimit / step;
                    count += upperLimit / step;
                    step *= primes[i];
                }
                // Create squared value
                squares.Add(BigInteger.ModPow(new BigInteger(primes[i]), 2 * count, modValue));
            }
            Console.WriteLine($"Squares  : {squares.Count}");

            // MultiplySquares(1, 0);

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static void MultiplySquares(BigInteger currentValue, int index)
        {
            if (index == squares.Count)
            {
                result += currentValue;
            }
            else
            {
                MultiplySquares(currentValue, index + 1);
                MultiplySquares((currentValue * squares[index]) % modValue, index + 1);
            }
        }
    }
}
