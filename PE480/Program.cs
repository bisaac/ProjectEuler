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
            BigInteger result = 0;

            //var phrase = "thereisasyetinsufficientdataforameaningfulanswer";
            var phrase = "aaaaaacdeeeeeeffffghiiiiilmnnnnnorrrssssttttuuwy";

            //BigInteger subcount = 1;
            //for (var count = 1; count <= 15; count++)
            //{
            //    for (var i = 2; i <= phrase.Length; i++)
            //        subcount *= i;
            //    //for (var i = 2; i <= count; i++)
            //    //    subcount /= i;
            //    for (var i = 2; i <= phrase.Length - count; i++)
            //        subcount /= i;

            //    // a
            //    for (var i = 2; i <= 6; i++)
            //        subcount /= i;
            //    // e
            //    for (var i = 2; i <= 6; i++)
            //        subcount /= i;
            //    // f
            //    for (var i = 2; i <= 4; i++)
            //        subcount /= i; ;
            //    // i
            //    for (var i = 2; i <= 5; i++)
            //        subcount /= i;
            //    // n
            //    for (var i = 2; i <= 5; i++)
            //        subcount /= i;
            //    // r
            //    for (var i = 2; i <= 3; i++)
            //        subcount /= i; ;
            //    // s
            //    for (var i = 2; i <= 4; i++)
            //        subcount /= i; ;
            //    // t
            //    for (var i = 2; i <= 4; i++)
            //        subcount /= i; ;
            //    // u
            //    for (var i = 2; i <= 2; i++)
            //        subcount /= i; ;

            //    result += subcount;
            //}

            //var testPhrase = "aabc";
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

            for (var p = 1; p <= phrase.Length; p++)
            {
                Variations<char> variations = new Variations<char>(inputSet, p, GenerateOption.WithoutRepetition);
                Console.WriteLine($"Variations of {{phrase}} choose {p}: size = {variations.Count}");
                result += variations.Count;
            }

            clock.Stop();
            Console.WriteLine("Is it   525069350231428029");
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
