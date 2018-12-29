using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public static class Helpers
    {
        public static string GetDataFromFile(string fileName)
        {
            return System.IO.File.ReadAllText(fileName).Replace("\"", "");
        }

        public static List<long> GeneratePrimeList(int maxNumber)
        {
            var primes = new List<long> { 2, 3 };

            for (long i = 5; i <= maxNumber; i += 6)
            {
                if (IsPrime(i)) primes.Add(i);
                if (IsPrime(i + 2)) primes.Add(i + 2);
            }

            return primes;
        }

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

        public static bool IsPrime(long n)
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

        public static int Gcd(int x, int y)
        {
            return y == 0 ? x : Gcd(y, x % y);
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

        public static List<long>[] GetPrimeFactorLists(long topNumber, BitArray primeList)
        {
            // Does not include 1

            var listArray = new List<long>[topNumber + 1];
            for (long i = 0; i <= topNumber; i++)
                listArray[i] = new List<long>();

            for (int i = 0; i <= topNumber; i++)
            {
                if (!primeList[i]) continue;

                long step = i;
                while (step <= topNumber)
                {
                    for (long j = step; j <= topNumber; j += step)
                    {
                        listArray[j].Add((long)i);
                    }

                    step *= i;
                }
            }

            return listArray;
        }

        public static long[] GetLargestPrimeFactors(long topNumber)
        {
            var largestPrime = new long[topNumber + 1];
            largestPrime[0] = 0;
            largestPrime[1] = 0;

            for (var i = 2; i <= topNumber; i++)
            {
                if (largestPrime[i] > 0) continue;

                for (var j = i; j <= topNumber; j += i)
                    largestPrime[j] = i;

                var k = i * i;
                while (k <= topNumber)
                {
                    largestPrime[k] = k;
                    k *= i;
                }
            }

            return largestPrime;
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

        public static long ModularMultiplicativeInverse(long a, long mod)
        {
            long m0 = mod;
            long y = 0;
            long x = 1;

            if (mod == 1) return 0;

            while (a > 1)
            {
                // q is quotient
                long q = a / mod;
                long t = mod;

                // m is remainder now; process same as Euclid's algorithm
                mod = a % mod;
                a = t;
                t = y;

                // Update y and x
                y = x - q * y;
                x = t;
            }

            // Make x positive
            if (x < 0)
                x += m0;

            return x;
        }

        private static void CreatePermutations(string start, List<char> charList, List<string> permutations)
        {
            for (int i = 0; i < charList.Count; i++)
            {
                var current = charList[i];
                charList.RemoveAt(i);
                if (charList.Count == 0)
                {
                    var permutation = String.Format("{0}{1}", start, current);
                    if (!permutations.Contains(permutation)) permutations.Add(permutation);
                }
                else
                    CreatePermutations(String.Format("{0}{1}", start, current), charList, permutations);
                charList.Insert(i, current);
            }
        }
        private static void CreatePermutations(string start, List<int> intList, List<string> permutations)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                var current = intList[i];
                intList.RemoveAt(i);
                if (intList.Count == 0)
                {
                    var permutation = String.Format("{0}{1}", start, current);
                    if (!permutations.Contains(permutation)) permutations.Add(permutation);
                }
                else
                    CreatePermutations(String.Format("{0}{1}", start, current), intList, permutations);
                intList.Insert(i, current);
            }
        }
        public static List<String> GetPermutations(string chars)
        {
            var permutations = new List<string>();
            var charList = chars.ToArray().ToList();
            //var intList = chars.Select(c => int.Parse(c.ToString())).ToList();

            CreatePermutations(null, charList, permutations);

            return permutations;
        }
    }
}