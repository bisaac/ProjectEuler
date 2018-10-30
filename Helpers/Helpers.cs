using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    public static class Helpers
    {
        public static ArrayList GeneratePrimes(int toGenerate)
        {
            ArrayList primes = new ArrayList();
            if (toGenerate > 0) primes.Add(2);
            int curTest = 3;
            while (primes.Count < toGenerate)
            {
                int sqrt = (int)Math.Sqrt(curTest);
                bool isPrime = true;
                for (int i = 0; i < primes.Count && (int)primes[i] <= sqrt; ++i)
                {
                    if (curTest % (int)primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                    primes.Add(curTest);
                curTest += 2;
            }
            return primes;
        }

        public static List<long> GetFactors(long v)
        {
            var results = new List<long>();

            for (long i = 1; i < Math.Sqrt(v); i++)
            {
                if (v % i == 0)
                {
                    results.Add(i);
                    results.Add(v / i);
                }
            }

            return results;
        }

        public static List<int> GenerateIntPrimesBySieve(int maxNumber)
        {
            var sieve = GeneratePrimeSieve(maxNumber);
            List<int> primes = new List<int>();
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public static List<long> GenerateLongPrimesBySieve(int maxNumber)
        {
            var sieve = GeneratePrimeSieve(maxNumber);
            List<long> primes = new List<long>();
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public static BitArray GeneratePrimeSieve(int maxNumber)
        {
            BitArray primes = new BitArray(maxNumber + 1, true);
            primes[0] = false;
            primes[1] = false;

            for (int i = 2; i <= maxNumber / 2; i++)
            {
                if (primes[i])
                    for (int j = i * 2; j <= maxNumber; j += i)
                    {
                        primes[j] = false;
                    }
            }

            return primes;
        }

        public static int GetFactorial(int number)
        {
            if (number < 1) return 1;
            if (number == 1) return 1;
            return number * GetFactorial(number - 1);
        }
        public static long GetFactorial(long number)
        {
            if (number < 1L) return 1L;
            if (number == 1L) return 1L;
            return number * GetFactorial(number - 1L);
        }
        public static BigInteger GetFactorial(BigInteger number)
        {
            if (number < 1) return 1;
            if (number == 1) return 1;
            return number * GetFactorial(number - 1);
        }

        public static List<int> GetPrimeFactors(int topNumber)
        {
            var primeList = GeneratePrimeSieve(topNumber);

            return GetPrimeFactors(topNumber, primeList);
        }

        public static List<int> GetPrimeFactors(int topNumber, BitArray primeList)
        {
            // Does not include 1

            var list = new List<int>();
            int value = topNumber;

            var primeIndex = 2;
            while (value > 1)
            {
                if (value % primeIndex == 0)
                {
                    value /= primeIndex;
                    list.Add(primeIndex);
                }
                else
                {
                    primeIndex++;
                    while (!primeList[primeIndex]) primeIndex++;
                }
            }

            return list;
        }
        public static List<PrimeFactor> GetPoweredPrimeFactors(int topNumber, BitArray primeList)
        {
            // Does not include 1

            var list = new List<PrimeFactor>();
            int value = topNumber;

            var primeIndex = 2;
            while (value > 1)
            {
                var currentValue = 1;
                var currentPrime = new PrimeFactor
                {
                    Prime = primeIndex,
                    Power = 0,
                    Value = 1
                };

                while (value % primeIndex == 0)
                {
                    value /= primeIndex;
                    currentValue *= primeIndex;
                    currentPrime.Power++;
                    currentPrime.Value *= primeIndex;
                }

                if (currentValue > 1) list.Add(currentPrime);
                primeIndex++;
                while (!primeList[primeIndex]) primeIndex++;
            }

            return list;
        }

        public static List<List<int>> GetPrimeFactorList(int topNumber, BitArray primeList)
        {
            // Does not include the number itself

            var list = new List<List<int>>();

            list.Add(new List<int>());
            list.Add(new List<int>());

            for (int i = 2; i <= topNumber; i++)
                list.Add(GetPrimeFactors(i, primeList));

            return list;
        }
    }
}