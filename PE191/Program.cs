using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        private const int OnTime = 0;
        private const int Absence = 1;
        private const int TwoAbsence = 2;
        private const int Late = 3;
        private const int LateAbsence = 4;
        private const int LateTwoAbsence = 5;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            var typeCount = new int[6];
            typeCount[OnTime] = 1;

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

            newTypeCount[OnTime] = typeCount[OnTime] + typeCount[Absence] + typeCount[TwoAbsence];
            newTypeCount[Absence] = typeCount[OnTime];
            newTypeCount[TwoAbsence] = typeCount[Absence];
            newTypeCount[Late] = typeCount[OnTime] + typeCount[Absence] + typeCount[TwoAbsence] + typeCount[Late] + typeCount[LateAbsence] + typeCount[LateTwoAbsence];
            newTypeCount[LateAbsence] = typeCount[Late];
            newTypeCount[LateTwoAbsence] = typeCount[LateAbsence];

            return newTypeCount;
        }
    }
}
