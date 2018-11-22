using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            string result = String.Empty;

            var positionNeeded = 2011;
            var cars = "ABCDEFGHIJK";

            var maximixes = CreatePermutations(cars);
            maximixes.Sort();
            result = maximixes[positionNeeded - 1];

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static List<string> CreatePermutations(string train)
        {
            var permutations = new List<string>();

            train = RotateStringEnd(train, 2);
            permutations.AddRange(CreatePermutations(train, 3));

            return permutations;
        }

        private static List<string> CreatePermutations(string train, int spin)
        {
            var permutations = new List<string>();

            var workingTrain = RotateStringEnd(train, spin);
            for (var i = 2; i < spin; i++)
            {
                if (spin == train.Length)
                    permutations.Add(RotateStringEnd(workingTrain, i));
                else
                    permutations.AddRange(CreatePermutations(RotateStringEnd(workingTrain, i), spin + 1));
            }

            return permutations;
        }

        private static string RotateStringEnd(string train, int numCars)
        {
            var sb = new StringBuilder();

            if (numCars < train.Length)
            {
                sb.Append(train.Substring(0, train.Length - numCars));
            }

            for (var i = 1; i <= numCars; i++)
            {
                sb.Append(train[train.Length - i]);
            }

            return sb.ToString();
        }
    }
}
