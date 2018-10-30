using System;
using System.Runtime.CompilerServices;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            long limit = 1000000000;

            for (long i = 1; i < limit; i += 2)
            {
                if (IsReversible(i))
                {
                    result += 2;
                }
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static bool IsReversible(long n)
        {
            if (n % 10 == 0) return false;

            var hold = n;
            long r = 0;

            while (hold > 0)
            {
                r = (r* 10) + (hold % 10);
                hold /= 10;
            }

            var sum = n + r;

            while (sum > 0)
            {
                if (sum % 2 == 0) return false;
                sum /= 10;
            }

            return true;
        }
    }
}
