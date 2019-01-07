using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            BigInteger result = 0;
            int upperLimit = 100000000;
            // int upperLimit = 100;

            var primeSieve = Helpers.GeneratePrimeSieve(upperLimit);
            var primes = Helpers.GenerateIntPrimesBySieve(upperLimit, primeSieve);

            for (var a = 0; a < primes.Count - 2; a++)
            {
                Console.WriteLine($"{primes[a],9}, {result}");
                double primeA = primes[a];
                bool bFlag = true;

                for (var b = a + 1; b < primes.Count - 1 && bFlag; b++)
                {
                    double primeB = primes[b];
                    double c = (primeB + 1) * (primeB + 1) / (primeA + 1) - 1;
                    bFlag = c < upperLimit;

                    if (bFlag && c == Math.Round(c) && primes.Contains((int)c))
                    {
                        result += primes[a] + primes[b] + (int)c;
                    }
                }}

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
