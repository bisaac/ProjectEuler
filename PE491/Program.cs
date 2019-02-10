using System;
using System.Collections;
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            BigInteger result = 0;

            var upperLimit = (int)Math.Pow(2, 20);

            var current = (int)Math.Pow(2, 10) - 1;
            while (current < upperLimit)
            {
                var bits = new BitArray(new int[] { current });
                if (IsUnusedNumber(bits) && DivisibleBy11(bits))
                {
                    long subtotal = 3628800L * 3628800L;  // 10! * 10!
                    for (var i = 0; i < 20; i += 2)
                        if (bits[i] == bits[i + 1]) subtotal /= 2;  // Divide by 2! when duplicates in on of the sets (should be in pairs)
                    result += subtotal;
                }
                current = Hakmem175(current);
            }

            result /= 10;
            result *= 9;

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static bool IsUnusedNumber(BitArray number)
        {
            for (var i = 0; i < 20; i += 2)
                if (number[i] && !number[i + 1]) return false;
            return true;
        }

        private static bool DivisibleBy11(BitArray number)
        {
            int sum = 0;
            for (var i = 0; i < 20; i++)
            {
                if(number[i]) sum += i/2;
            }
            return (90 - 2 * sum) % 11 == 0;
        }

        // This function returns the next highest number containing the same number of bits
        private static int Hakmem175(int value)
        {
            // find the lowest one bit in the input
            var lowestBit = value & -value;

            // determine the leftmost bits of the output
            var leftBits = value + lowestBit;

            // determine the difference between the input and leftmost output bits (XOR)
            var changedBits = value ^ leftBits;

            // determine the rightmost bits of the output
            var rightBits = (changedBits / lowestBit) >> 2;

            // return the complete output
            return (leftBits | rightBits);
        }
    }
}
