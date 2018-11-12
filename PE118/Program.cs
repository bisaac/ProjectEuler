using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        private static BitArray _primes;
        private static List<int> _primeList;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            _primes = Helpers.GeneratePrimeSieve(1000000000);
            FindPrimesWithoutRepeats();
            result = _primeList.Count;

            var setGenerator = new SetGenerator(_primeList);
            setGenerator.BuildMatrix();
            result = setGenerator.CreateSets();

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static void FindPrimesWithoutRepeats()
        {
            _primeList = new List<int>();

            for (var i = 2; i < _primes.Count; i++)
                if (_primes[i] && CheckForDuplicate(i))  _primeList.Add(i);
        }

        private static bool CheckForDuplicate(int n)
        {
            var digits = new BitArray(10, false);

            while (n > 0)
            {
                var d = n % 10;
                if (d == 0) return false;
                if (digits[d]) return false;
                digits[d] = true;
                n /= 10;
            }

            return true;
        }
    }
}
