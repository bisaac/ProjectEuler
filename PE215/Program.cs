using System;
using System.Collections.Generic;
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

            var layers = GetWallLayers(32);
            result = layers.Count;

            var subLayers = new Dictionary<int, List<int>>();
            foreach(var w in layers)
            {
                subLayers.Add(w, layers.Where(l => (l & w) == 1).ToList());
            }

            result = BuildWall(10, subLayers);   // 1 = ground

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static long BuildWall(int height, Dictionary<int, List<int>> subLayers)
        {
            if (height == 1) return subLayers.Count;

            long count = 0;
            foreach (var layer in GetWallCounts(height, subLayers))
            {
                count += layer.Value;
            }
            return count;
        }

        private static Dictionary<int, long> GetWallCounts(int height, Dictionary<int, List<int>> subLayers)
        {
            var wallCounts = new Dictionary<int, long>();

            if (height == 1)
            {
                foreach (var layer in subLayers)
                {
                    // wallCounts.Add(layer.Key, layer.Value.Count);
                    wallCounts.Add(layer.Key, 1);
                }
            }
            else
            {
                var subLayerCounts = GetWallCounts(height - 1, subLayers);
                foreach (var layer in subLayers)
                {
                    long count = 0;
                    foreach (var sublayer in subLayers[layer.Key])
                    {
                        count += subLayerCounts[sublayer];
                    }
                    wallCounts.Add(layer.Key, count);
                }
            }

            return wallCounts;
        }

        private static List<int> GetWallLayers(int length)
        {
            var layers = new List<int>();

            layers.AddRange(GetWallLayers(2, 1, length - 2));
            layers.AddRange(GetWallLayers(3, 1, length - 3));

            return layers;
        }

        private static List<int> GetWallLayers(int startLength, int startLayer, int length)
        {
            var layers = new List<int>();

            if (length < 0) return layers;
            if (length == 0) layers.Add(startLayer);
            if (length >= 2) layers.AddRange(GetWallLayers(startLength + 2, startLayer * 4 + 1, length - 2));
            if (length >= 3) layers.AddRange(GetWallLayers(startLength + 3, startLayer * 8 + 1, length - 3));

            return layers;
        }
    }
}
