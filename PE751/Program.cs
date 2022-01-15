using System;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            string result = "UNSOLVED";

            decimal theta = 2.2M;
            var places = 1;
            string strTheta = theta.ToString("F" + places);
            var previousNumber = 2;
            var step = 0.1M;

            while (strTheta.Length < 26)
            {
                var hold = GetConcatenatedString(theta);
                Console.WriteLine("Theta: " + strTheta + ",  ConcatString: " + hold);

                if (hold.Substring(0, strTheta.Length) == strTheta)
                {
                    step /= 10.0M;
                    places++;
                    var i = 1;
                    var nextValue = int.Parse(hold.Substring(strTheta.Length, i));
                    while (nextValue < previousNumber)
                    {
                        nextValue = int.Parse(hold.Substring(strTheta.Length, ++i));
                        step /= 10.0M;
                        places++;
                    }
                    theta = theta + (decimal)(nextValue * step);
                    previousNumber = nextValue;
                    strTheta = theta.ToString("F" + places);
                }
            }

            result = strTheta;

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        static string GetConcatenatedString(decimal theta)
        {
            string a = "2.";
            decimal previous = theta;

            while (a.Length < 26)
            {
                var flr = Math.Floor(previous);
                var b = flr * (previous - flr + 1);
                a += Math.Floor(b).ToString();
                previous = b;
            }

            return a;
        }
    }
}
