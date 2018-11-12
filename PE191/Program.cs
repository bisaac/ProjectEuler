using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        private static int onTime = 0;
        private static int absence = 1;
        private static int twoAbsence = 2;
        private static int late = 3;
        private static int lateAbsence = 4;
        private static int lateTwoAbsence = 5;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            var typeCount = new int[6];
            typeCount[onTime] = 1;

            var days = 30;

            for (var i = 0; i < days; i++)
                typeCount = UpdateTypeCounts(typeCount);

            result = typeCount.Sum();

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static int[] UpdateTypeCounts(int[] typeCount)
        {
            var newTypeCount = new int[6];

            newTypeCount[onTime] = typeCount[onTime] + typeCount[absence] + typeCount[twoAbsence];
            newTypeCount[absence] = typeCount[onTime];
            newTypeCount[twoAbsence] = typeCount[absence];
            newTypeCount[late] = typeCount[onTime] + typeCount[absence] + typeCount[twoAbsence] + typeCount[late] + typeCount[lateAbsence] + typeCount[lateTwoAbsence];
            newTypeCount[lateAbsence] = typeCount[late];
            newTypeCount[lateTwoAbsence] = typeCount[lateAbsence];

            return newTypeCount;
        }
    }
}
