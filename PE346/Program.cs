using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        private static ulong topNum = 1000000000000;

        static void Main(string[] args)
        {
            ulong result = 0;
            List<ulong> repunits = new List<ulong> { 1L };

            ulong numLimit = (ulong)Math.Sqrt(topNum);

            for (ulong b = 2; b <= numLimit; b++)
            {
                var current = b * b + b + 1L;
                while (current < topNum)
                {
                    if (!repunits.Contains(current)) repunits.Add(current);
                    current = (current * b) + 1L;
                }
            }

            var duplicates = repunits.GroupBy(x => x)
                                .Select(y => y.Key)
                                .ToList();

            foreach (var i in duplicates)
            {
                result += i;
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
