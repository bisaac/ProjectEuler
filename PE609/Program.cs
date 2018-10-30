using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ProjectEuler
{
    class Program
    {
        private static BitArray primes;
        private static int[] piResults;

        static void Main(string[] args)
        {
            long result = 1;
            int limit = 100000000;
            long modValue = 1000000007;

            GeneratePrimeLists(limit);

            var counts = new long[limit + 1];
            var pnk = new List<long>[limit + 1];
            pnk[1] = new List<long>();

            for (var i = 2; i <= limit; i++)
            {
                var primeValue = primes[i] ? 0 : 1;
                var piValue = primes[piResults[i]] ? 0 : 1;
                counts[primeValue + piValue] = (counts[primeValue + piValue] + 1) % modValue;
                pnk[i] = new List<long>{ primeValue + piValue };
                foreach (var list in pnk[piResults[i]])
                {
                    var tempValue = list + primeValue;
                    counts[tempValue] = (counts[tempValue] + 1) % modValue;
                    pnk[i].Add(tempValue);
                }
            }

            for (long i = 0; i <= limit; i++)
            {
                if (counts[i] == 0) continue;
                result = (result * counts[i]) % modValue;
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static void GeneratePrimeLists(int n)
        {
            primes = new BitArray(n + 1, true);
            primes[0] = false;
            primes[1] = false;

            for (int i = 2; i <= n / 2; i++)
            {
                if (primes[i])
                    for (int j = i * 2; j <= n; j += i)
                    {
                        primes[j] = false;
                    }
            }

            piResults = new int[n + 1];
            var counter = 0;
            for (int i = 2; i <= n; i++)
            {
                if (primes[i])
                {
                    counter++;
                }

                piResults[i] = counter;
            }
        }
    }
}
