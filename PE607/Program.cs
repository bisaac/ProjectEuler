using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ProjectEuler
{
    class Program
    {
        private static int counter = 0;
        private static double delta = 0.001;


        static void Main(string[] args)
        {
            double result = 200.0;
            double marginError = 0.0000000000005;

            var routeList = new List<Route>();
            for (var i = 0; i < 128; i++)
            {
                var route = new Route();
                if (route.TravelTime < result) result = route.TravelTime;
                // Console.WriteLine("Route " + i + ": " + route.TravelTime);
                routeList.Add(route);
            }

            // var previousMinimum = 13.4738;
            var previousMinimum = 200.00;

            //while (Math.Abs(result - previousMinimum) >= marginError)
            //while (true)
            while (routeList.Max(r => r.TravelTime) - routeList.Min(r => r.TravelTime) >= marginError)
            {
                    if (previousMinimum > result) previousMinimum = result;

                // Create next generation
                routeList = CreateNextGeneration(routeList);
                result = routeList.Min(p => p.TravelTime);
                Console.WriteLine(result);
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static List<Route> CreateNextGeneration(List<Route> routeList)
        {
            var parents = routeList.OrderBy(r => r.TravelTime).ToList();
            var children = new List<Route>();
            var scale = (parents.Count * (parents.Count + 1)) / 2;
            var rnd = new Random();

            for (var i = 0; i < parents.Count; i++)
            {
                var parent1 = rnd.Next(scale) - parents.Count;
                var parent2 = rnd.Next(scale) - parents.Count;

                var parent1Index = 0;
                var parent2Index = 0;

                while (parent1 > 0)
                {
                    parent1Index++;
                    parent1 -= parents.Count - parent1Index;
                }

                while (parent2 > 0)
                {
                    parent2Index++;
                    parent2 -= parents.Count - parent2Index;
                }

                children.Add(Procreate(parents[parent1Index], parents[parent2Index], delta));
            }

            counter = (counter + 1) % 100000;
            if (counter == 0) delta /= 100.0;

            return children;
        }

        private static Route Procreate(Route route1, Route route2, double delta = 0.000000001)
        {
            var rnd = new Random();
            var crossover = rnd.Next(7);
            var mutation = rnd.Next(7);

            var crossings = new double[6];
            for (var i = 0; i < 6; i++)
            {
                crossings[i] = (i < crossover) ? route1.Crossing[i] : route2.Crossing[i];
            }

            if (mutation < 6)
            {
                crossings[mutation] += 2 * (rnd.NextDouble() - 0.5) * delta;
            }

            return new Route(crossings[0], crossings[1], crossings[2], crossings[3], crossings[4], crossings[5]);
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
