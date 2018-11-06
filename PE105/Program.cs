using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;

            //var set1 = new int[] {81, 88, 75, 42, 87, 84, 65};
            //var set2 = new int[] {157, 150, 164, 119, 79, 159, 161, 139, 158};

            //var result1 = SpecialSetSum(set1);
            //var result2 = SpecialSetSum(set2);

            var setList = Helpers.GetDataFromFile(@"C:\Projects\ProjectEuler\PE105\p105_sets.txt")
                .Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line =>
                    line.Split(',')
                        .Select(token => int.Parse(token)).ToArray()).ToList();

            foreach (var t in setList)
                result += SpecialSetSum(t);

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static int SpecialSetSum(int[] set)
        {
            var overallTotal = set.Sum();
            var maxCombination = (int)Math.Pow(2, set.Length) - 1;
            BitArray sums = new BitArray(overallTotal + 1, false);
            var min = new int[set.Length + 1];
            var max = new int[set.Length + 1];
            for (var i = 0; i < min.Length; i++)
                min[i] = overallTotal + 1;


            for (var i = 1; i < maxCombination; i++)
            {
                var total = 0;
                var count = NumberOfSetBits(i);
                var terms = new BitArray(new [] {i});

                for (var j = 0; j < set.Length; j++)
                {
                    if (terms[j])
                        total += set[j];
                }

                if (sums[total]) return 0;
                sums[total] = true;

                if (max[count] < total) max[count] = total;
                if (min[count] > total) min[count] = total;

                for (var j = 1; j < count; j++)
                {
                    if (max[j] > min[j+1]) return 0;
                }

            }

            return overallTotal;
        }

        private static int NumberOfSetBits(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }
    }
}
