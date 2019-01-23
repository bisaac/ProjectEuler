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
                for (var j = 0; j < i; j++)
                {
                    if (points[i].X == points[j].X && points[i].Y == points[j].Y) continue;
                    lines.Add(new Line(points[i], points[j]));
                }
            }

            lines = lines.OrderBy(l => l.SlopeY).ThenBy(l => l.SlopeX).ThenBy(l => l.PointX).ThenBy(l => l.PointY).ToList();

            var k = 0;
            while (k < lines.Count-1)
            {
                var next = 1;
                while (lines[k].SlopeX == lines[k + next].SlopeX && lines[k].SlopeY == lines[k + next].SlopeY)
                {
                    if (lines[k].SlopeX * (lines[k + next].PointY - lines[k].PointY) == lines[k].SlopeY * (lines[k + next].PointX - lines[k].PointX)) // Same line
                        lines.RemoveAt(k + next);
                    else
                        next++;
                }
                k++;
            }

            Console.WriteLine($"Lines: {lines.Count}");

            #region Add up line intersections

            long holdSlopeX = lines[0].SlopeX;
            long holdSlopeY = lines[0].SlopeY;
            long lineCount = 1;

            for (var i = 1; i < lines.Count; i++)
            {
                if (holdSlopeX != lines[i].SlopeX || holdSlopeY != lines[i].SlopeY)
                {
                    result += ((long)lines.Count - lineCount) * lineCount;
                    holdSlopeX = lines[i].SlopeX;
                    holdSlopeY = lines[i].SlopeY;
                    lineCount = 0;
                }
                lineCount++;
            }
            result += ((long)lines.Count - lineCount) * lineCount;

            #endregion

            #region Subtractive

            //result = new BigInteger(lines.Count) * new BigInteger(lines.Count - 1);

            //for (var i = 0; i < lines.Count - 1; i++)
            //{
            //    if (lines[i].SlopeX == lines[i + 1].SlopeX && lines[i].SlopeY == lines[i + 1].SlopeY)
            //    {
            //        //Console.WriteLine("Before : " + result);
            //        var matches = 1;
            //        while (lines[i].SlopeX == lines[i + matches].SlopeX && lines[i].SlopeY == lines[i + matches].SlopeY) matches++;
            //        result -= matches * (matches - 1);
            //        i += matches - 1;
            //    }
            //}

            #endregion

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
