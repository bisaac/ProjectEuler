using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger m = 10000000;
            BigInteger z = 1000000000000000;
            var v = new List<BigInteger> {1};

            for (BigInteger n = 2; n < m; n++)
            {
                BigInteger p = n;
                while (p <= z)
                {
                    p *= n;
                    BigInteger s = SumDigits(p);
                    if (n == s)
                        v.Add(p);
                }
            }
            v.Sort();

            Console.WriteLine("Answer: " + v[30]);
            Console.ReadLine();
        }

        private static BigInteger SumDigits(BigInteger n)
        {
            BigInteger result = 0;
            while (n > 9)
            {
                result += n % 10;
                n /= 10;
            }
            return result + n;
        }
    }
}
