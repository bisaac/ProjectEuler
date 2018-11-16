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
            int topNumber = 118;

            var sizes = new int[topNumber + 1, topNumber + 1, topNumber + 1];

            for (var x = 1; x <= topNumber; x++)
                for (var y = x; y <= topNumber / x; y++)
                    for (var z = y; z <= topNumber / (x * y); z++)
                    {
                        var layer = 1;
                        var layerSize = 0;
                        while (layerSize <= topNumber)
                        {
                            layerSize = getLayerSize(x, y, z, layer);
                            // Console.WriteLine(String.Format("{0}-{1}-{2} : {3}",x,y,z,layerSize));
                            if (layerSize == topNumber) result++;
                            layer++;
                        }
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
