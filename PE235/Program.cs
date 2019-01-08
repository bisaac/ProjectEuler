using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            double result = 0;
            double desired = -600000000000;

            double upper = 1.05;
            double lower = 1.00;

            double mid = 0;
            double diff = 2;

            while (Math.Abs(diff) > 1)
            {
                mid = (upper + lower) / 2.0;
                var sum = Sumof5000Terms(mid);
                diff = desired - sum;

                if (diff > 0)
                {
                    upper = mid;
                }
                else
                {
                    lower = mid;
                }
            }

            result = Math.Round(mid,12);

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static double Sumof5000Terms(double r)
        {
            double result = 0;

            double geo = 1;
            for (var k = 1; k <= 5000; k++)
            {
                result += (900 - 3 * k) * geo;
                geo *= r;
            }

            return result;
        }

        private static double s(double r)
        {
            double result = (897.0 + 14103.0 * Math.Pow(r, 5000.0)) / (1.0 - r);

            result += (-3.0 * r / ((1.0 - r) * (1.0 - r))) * (1.0 - Math.Pow(r, 5000.0));

            return result;
        }
    }
}
