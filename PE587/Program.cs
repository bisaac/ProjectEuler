using System;
using System.Xml.XPath;

namespace ProjectEuler
{
    class Program
    {

        static void Main(string[] args)
        {
            double result = 0;

            //double r = 1.0;
            double fullArea = 1.0 - Math.PI / 4.0;

            double percentCoverage = 1;
            double numCircles = 0;

            while (percentCoverage >= 0.001)
            {
                numCircles++;

                //var x2 = 1;
                //var y2 = 1;

                //var x1 = x2 - 2 * numCircles;
                //var y1 = y2 - 2;

                //var x1 = 1 - 2 * numCircles;
                //var y1 = -1;

                //var dx = x2 - x1;
                //var dy = y2 - y1;
                //var D = (x1 * y2) - (x2 * y1);
                //var drSq = (dx * dx) + (dy * dy);

                var dx = 2 * numCircles;
                var dy = 2;
                var D = 2 * (1 - numCircles);
                var drSq = (dx * dx) + 4;

                var ix = (D * dy + dx * Math.Sqrt(drSq - D * D)) / drSq;
                var iy = (-D * dx + dy * Math.Sqrt(drSq - D * D)) / drSq;

                var areaTri = 0.5 * (1 - iy);

                var chordLen = Math.Sqrt((ix * ix) + (1 - iy) * (1 - iy));
                var angle = 2.0 * Math.Asin(chordLen / 2.0);
                var areaSegment = (angle - Math.Sin(angle)) / 2.0;

                percentCoverage = (areaTri - areaSegment) / fullArea;
            }

            result = numCircles;

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
