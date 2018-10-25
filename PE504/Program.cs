using System;
using System.Collections.Generic;
using System.Linq;

namespace PE504
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            // int M = 4;  // 42
            // int M = 10;  // 862
            int M = 100; // ?

            var squareList = new List<int>();
            for (var i = 1; i <= (2 * M); i++)
            {
                squareList.Add(i*i);
            }

            var counts = new int[M + 1, M + 1];

            for (double x = 1; x <= M; x++)
            {
                for (double y = 1; y <= M; y++)
                {
                    double count = 0;
                    for (double col = 1; col < x; col++)
                    {
                        var colTotal = ((-y * col) / x) + y;
//                        if(colTotal != Math.Floor(colTotal))
                            count += Math.Ceiling(colTotal - 1);
                    }

                    counts[(int) x, (int) y] = (int) count;
                }
            }
            
            for (var a = 1; a <= M; a++)
            for (var b = 1; b <= M; b++)
            for (var c = 1; c <= M; c++)
            for (var d = 1; d <= M; d++)
            {
                var totalPoints = 0;
                totalPoints += counts[a, b];
                totalPoints += counts[c, b];
                totalPoints += counts[c, d];
                totalPoints += counts[a, d];
                totalPoints += a + b + c + d - 3;

                if (squareList.Contains(totalPoints)) result += 1;

                //Console.WriteLine(String.Format("{0}  {1}  {2}  {3}  {4}  {5}",a,b,c,d, totalPoints, result));
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
