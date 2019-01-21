using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            BigInteger result = 0;
            var n = 2500;

            var points = GetPoints(n);
            var lines = new List<Line>();

            for (var i = 1; i < points.Count; i++)
            {
                Console.WriteLine(i);
                for (var j = 0; j < i; j++)
                {
                    var line = new Line(points[i], points[j]);
                    //if (!lines.Any(l => l.SlopeX == line.SlopeX && l.SlopeY == line.SlopeY && l.PointX == line.PointX && l.PointY == line.PointY))
                    //{
                    //    lines.Add(line);
                    //}
                    var found = false;
                    for (var l = 0; !found && l < lines.Count; l++)
                        found = (line.SlopeX == lines[l].SlopeX && line.SlopeY == lines[l].SlopeY && line.PointX == lines[l].PointX && line.PointY == lines[l].PointY);
                    if (!found) lines.Add(line);
                }
            }

            //Console.WriteLine($"{lines.Count} lines");
            //Console.WriteLine("24477690");  // for n = 100
            foreach (var line in lines)
            {
                result += lines.Count(l => l.SlopeX != line.SlopeX || l.SlopeY != line.SlopeY);
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static List<Point> GetPoints(int count)
        {
            var values = new List<Point>();
            var t = GetTValues(2 * count);
            for (int i = 1; i <= count; i++)
                values.Add(new Point(t[2 * i - 1], t[2 * i]));
            return values;
        }

        private static List<int> GetTValues(int count)
        {
            var values = new List<int> { 0 };
            var s = GetSValues(count);
            for (var i = 1; i <= count; i++)
                values.Add((int)(s[i] % 2000) - 1000);
            return values;
        }

        private static List<long> GetSValues(int count)
        {
            var values = new List<long> { 290797 };
            for (var i = 1; i <= count; i++)
                values.Add((values[i - 1] * values[i - 1]) % 50515093);
            return values;
        }
    }

    class Point
    {
        public long X { get; }
        public long Y { get; }

        public Point(long x, long y)
        {
            X = x;
            Y = y;
        }
    }

    class Line
    {
        public long SlopeX { get; }
        public long SlopeY { get; }
        public long PointX { get; }
        public long PointY { get; }

        public Line(Point p1, Point p2)
        {
            SlopeX = (p2.X - p1.X);
            SlopeY = (p2.Y - p1.Y);

            if (SlopeX == 0)
            {
                SlopeY = 1;
                PointX = p1.X;
                PointY = 0;
            }
            else if (SlopeY == 0)
            {
                SlopeX = 1;
                PointX = 0;
                PointY = p1.Y;
            }
            else
            {
                var gcd = Gcd(SlopeX, SlopeY);
                SlopeX = SlopeX / gcd;
                SlopeY = SlopeY / gcd;

                if (SlopeY < 0)
                {
                    SlopeX *= -1;
                    SlopeY *= -1;
                }

                PointX = p1.X;
                PointY = p1.Y;

                while (PointY < 0)
                {
                    PointX += SlopeX;
                    PointY += SlopeY;
                }
                while (PointY > 0 && PointY > SlopeY)
                {
                    PointX -= SlopeX;
                    PointY -= SlopeY;
                }
            }

        }

        public static long Gcd(long x, long y)
        {
            return y == 0 ? x : Gcd(y, x % y);
        }
    }
}
