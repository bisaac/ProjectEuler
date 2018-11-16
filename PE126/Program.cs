using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;
            int topNumber = 20000;
            int goal = 1000;
            var totals = new int[topNumber+1];

            for (var x = 1; getLayerSize(x,x,x,1) <= topNumber; x++)
                for (var y = x; getLayerSize(x, x, y, 1) <= topNumber; y++)
                    for (var z = y; getLayerSize(x, y, z, 1) <= topNumber; z++)
                        for (var l = 1; getLayerSize(x, y, z, l) <= topNumber; l++)
                            {
                                // Console.WriteLine("{0} - {1} - {2}", x, y, z);
                                var layerSize = getLayerSize(x, y, z, l);
                                if (layerSize <= topNumber) totals[layerSize]++;
                            }

            for (var i = 0; i < totals.Length; i++)
            {
                if (result == 0 && totals[i] == goal)
                    result = i;
            }

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static int getLayerSize(int x, int y, int z, int l)
        {
            if (l == 0) return x * y * z;
            if (l == 1) return (x * y + y * z + z * x) * 2;

            return (x * y + y * z + z * x) * 2 + 4 * (x + y + z) * (l - 1) + 8 * getTriangleNumber(l - 2);
        }

        private static int getTriangleNumber(int n)
        {
            return (n * (n + 1)) / 2;
        }
    }
}
