using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 1;

            var values = Helpers.GenerateLongPrimesBySieve(7376507);

            for (var i = 1; i <= 500500; i++)
            {
                var minValue = values.Min();
                result = (result * minValue) % 500500507;

                var index = values.IndexOf(minValue);
                values[index] *= minValue;

                Console.WriteLine("i: " + i + ", minValue: " + minValue + ", result: " + result);
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
