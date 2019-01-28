using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using Combinatorics.Collections;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            long result = 0;

            var phrase = "aabbbcd";
            var inputSet = phrase.ToCharArray();

            //Combinations<char> variations = new Combinations<char>(inputSet, 5, GenerateOption.WithoutRepetition);
            //Console.WriteLine($"Variations of {{phrase}} choose 5: size = {variations.Count}");
            //foreach (IList<char> v in variations)
            //{
            //    Console.Write("{{");
            //    for (var k = 0; k < v.Count; k++)
            //        Console.Write(v[k]);
            //    Console.WriteLine("}}");
            //}

            ////for (var p = 1; p <= phrase.Length; p++)
            //for (var p = 1; p <= 15; p++)
            //{
            //    Variations<char> variations = new Variations<char>(inputSet, p, GenerateOption.WithoutRepetition);
            //    Console.WriteLine($"Variations of {{phrase}} choose {p}: size = {variations.Count}");
            //    result += variations.Count;
            //}

            var variants = new List<string>();

            Console.WriteLine("Duplicates allowed");
            for (var p = 1; p <= phrase.Length; p++)
            {
                Variations<char> variations = new Variations<char>(inputSet, p, GenerateOption.WithoutRepetition);
                Console.WriteLine($"Variations of {{ {phrase} }} choose {p}: size = {variations.Count, 4}");
                result += variations.Count;
                foreach(var v in variations)
                {
                    var vWord = new String(v.ToArray());
                    if (!variants.Contains(vWord)) variants.Add(vWord);
                }
            }
            Console.WriteLine($"Variations with duplicates:    {result, 5}");
            Console.WriteLine();

            Console.WriteLine("Duplicates not allowed");
            for (var p = 1; p <= phrase.Length; p++)
            {
                Console.WriteLine($"Variations of {{ {phrase} }} choose {p}: size = {variants.Count(v => v.Length == p),4}");
            }
            Console.WriteLine($"Variations without duplicates: {variants.Count, 5}");
            Console.WriteLine();




            clock.Stop();
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
