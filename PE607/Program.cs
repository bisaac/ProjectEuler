using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 200.0;
            double marginError = 0.00000000005;

            var routeList = new List<Route>();
            for (var i = 0; i < 24; i++)
            {
                var route = new Route();
                if (route.TravelTime < result) result = route.TravelTime;
                Console.WriteLine("Route " + i + ": " + route.TravelTime);
                routeList.Add(route);
            }

            var previousMinimum = 13.4738;

            while (Math.Abs(result - previousMinimum) > marginError)
            {
                previousMinimum = result;

                // Create next generation
                var parents = routeList.OrderBy(r => r.TravelTime).ToList();
                result = parents.Min(p => p.TravelTime);

            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }

    class Route
    {
        private double _travelTime = 0.0;

        public double[] Crossing;

        public Route()
        {
            _travelTime = 0.0;
            var rnd = new Random();
            Crossing = new double[6] {100*rnd.NextDouble(), 100 * rnd.NextDouble(), 100 * rnd.NextDouble(), 100 * rnd.NextDouble(), 100 * rnd.NextDouble(), 100 * rnd.NextDouble()};
        }

        public Route(double a, double b, double c, double d, double e, double f)
        {
            _travelTime = 0.0;
            Crossing = new double[] {a,b,c,d,e,f};
        }

        public double TravelTime
        {
            get {
                if (_travelTime.Equals(0.0))
                {
                    _travelTime += GetDistance(0, 0, Crossing[0], Crossing[0] - (50 - 25 * Math.Sqrt(2))) / 10.0;
                    _travelTime += GetDistance(Crossing[0], Crossing[0] - (50 - 25 * Math.Sqrt(2)), Crossing[1], Crossing[1] - (50 - 15 * Math.Sqrt(2))) / 9.0;
                    _travelTime += GetDistance(Crossing[1], Crossing[1] - (50 - 15 * Math.Sqrt(2)), Crossing[2], Crossing[2] - (50 - 05 * Math.Sqrt(2))) / 8.0;
                    _travelTime += GetDistance(Crossing[2], Crossing[2] - (50 - 05 * Math.Sqrt(2)), Crossing[3], Crossing[3] - (50 + 05 * Math.Sqrt(2))) / 7.0;
                    _travelTime += GetDistance(Crossing[3], Crossing[3] - (50 + 05 * Math.Sqrt(2)), Crossing[4], Crossing[4] - (50 + 15 * Math.Sqrt(2))) / 6.0;
                    _travelTime += GetDistance(Crossing[4], Crossing[4] - (50 + 15 * Math.Sqrt(2)), Crossing[5], Crossing[5] - (50 + 25 * Math.Sqrt(2))) / 5.0;
                    _travelTime += GetDistance(Crossing[5], Crossing[5] - (50 + 25 * Math.Sqrt(2)), 100, 0) / 10.0;
                }

                return _travelTime;
            }
        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }
}
