using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        private static BitArray primeArray;
        private static long[] factorialArray;

        static void Main(string[] args)
        {
            long result = 0;

            var numSolve = 100000000;

            //var primeArray = Helpers.GenerateLongPrimesBySieve(numSolve);
            primeArray = Helpers.GeneratePrimeSieve(numSolve);
            factorialArray = new long[numSolve + 1];

            for (int n = 2; n <= numSolve; n++)
            {
                if (!primeArray[n]) continue;

                long currentMultiple = 1;
                long currentFactor = n;
                long currentPower = currentFactor;

                while(currentPower < numSolve)
                {
                    while (currentFactor % currentPower != 0)
                    {
                        currentMultiple++;
                        currentFactor *= currentMultiple * n;
                    }

                    for(var j = 1; currentPower * j < numSolve; j++)
                    {
                        if (factorialArray[currentPower * j] < currentMultiple * n)
                            factorialArray[currentPower * j] = currentMultiple * n;
                    }

                    currentPower *= n;
                }
            }

            for (var n = 2; n <= numSolve; n++)
            {
                result += s(n);
            }

            Console.WriteLine("Answer: " + numSolve + " -> " + result);
            Console.ReadLine();
        }

        private static long s(int n)
        {
            // Check if exists (powers)

            if (factorialArray[n] != 0) return factorialArray[n];

            var factors = Helpers.GetPoweredPrimeFactors(n, primeArray);

            // Get maximum factorial needed
            return factors.Max(f => factorialArray[f.Value]);
        }
    }
}