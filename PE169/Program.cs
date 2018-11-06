using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        private static Dictionary<BigInteger, BigInteger> cache;

        static void Main(string[] args)
        {
            BigInteger result = 0;

            cache = new Dictionary<BigInteger, BigInteger>();
            cache.Add(0,1);

            var number = BigInteger.Parse("10000000000000000000000000");
            result = f(number);

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static BigInteger f(BigInteger n)
        {
            // OEIS  A002487
            if (n == 0) return 1;

            if (!cache.ContainsKey(n))
            {
                if (n % 2 == 0)
                {
                    cache.Add(n, f(n / 2) + f(n / 2 - 1));
                }
                else
                {
                    cache.Add(n, f((n - 1) / 2));
                }
            }

            return cache[n];
        }
    }
}
