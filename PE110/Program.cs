using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        // Borrows heavily from blog posts at https://www.mathblog.dk/project-euler-108-diophantine-equation/ 
        //    and https://www.mathblog.dk/project-euler-110-efficient-diophantine-equation/

        private static List<int> _primes;
        private static int[] _exponents;
        private static BigInteger result;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();

            _primes = Helpers.GenerateIntPrimesBySieve(50);
            _exponents = new int[_primes.Count];

            // Set result to product; reset when find smaller number
            result = 1;
            _primes.ForEach(x => result *= x);

            var numberToExceed = 4000000;
            var upperLimit = numberToExceed * 2 - 1;

            var exponentPosition = 1;

            while (true)
            {
                SetTwoExponent(upperLimit);

                // An exponent for a value must not be less than one for a higher value
                if (_exponents[0] < _exponents[1])
                {
                    //invalid combination - move to next position 
                    exponentPosition++;
                }
                else
                {
                    BigInteger number = GetNumber();
                    if (number < result)
                    {
                        Console.WriteLine(number);
                        result = number;
                    }
                    exponentPosition = 1;
                }

                if (exponentPosition >= _exponents.Length)
                    break;

                _exponents[exponentPosition]++;
                SetAllSmallerExponents(exponentPosition);
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        // Hydrate the number, if smaller than current result
        private static BigInteger GetNumber()
        {
            BigInteger number = 1;

            for (int i = 0; i < _exponents.Length; i++)
            {
                if (_exponents[i] == 0) break;

                number *= BigInteger.Pow(_primes[i], _exponents[i]);

                if (number > result) return result + 1;
            }

            return number;
        }

        // Set max exponent value for 2, based on number of divisors allowed
        private static void SetTwoExponent(long limit)
        {
            _exponents[0] = 0;
            long divisors = 1;

            for (int i = 0; i < _exponents.Length; i++)
            {
                divisors *= 2 * _exponents[i] + 1;
            }
            _exponents[0] = (int)(limit / divisors - 1) / 2;

            while (divisors * (2 * _exponents[0] + 1) < limit)
                _exponents[0]++;
        }

        private static void SetAllSmallerExponents(int position)
        {
            for (int i = 0; i < position; i++)
            {
                _exponents[i] = _exponents[position];
            }
        }
    }
}
