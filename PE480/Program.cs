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
        static private BigInteger result = 0;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();

            // var phrase = "thereisasyetinsufficientdataforameaningfulanswer";
            // var phrase = "aaaaaacdeeeeeeffffghiiiiilmnnnnnorrrssssttttuuwy";
            var phraseLetters = new char[] { 'a', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'l', 'm', 'n', 'o', 'r', 's', 't', 'u', 'w', 'y' };
            //var letterCounts = new int[] { 6, 1, 1, 6, 4, 1, 1, 5, 1, 1, 5, 1, 3, 4, 4, 2, 1, 1 };
            var letterCounts = new int[] { 5, 1, 1, 6, 4, 1, 1, 5, 1, 1, 5, 1, 3, 4, 4, 2, 1, 1 };
            //var phrase = "aabbbcd";
            //var phraseLetters = new char[] { 'a', 'b', 'c', 'd' };
            //var letterCounts = new int[] { 2, 3, 1, 1 };

            //var inputSet = phrase.ToCharArray();
            //for (var p = 1; p <= phrase.Length; p++)
            //{
            //    Variations<char> variations = new Variations<char>(inputSet, p, GenerateOption.WithoutRepetition);
            //    Console.WriteLine($"Variations of {{phrase}} choose {p}: size = {variations.Count}");
            //    result += variations.Count;
            //}

            result++;
            FindCountForLength(14, letterCounts);

            clock.Stop();
            Console.WriteLine("Is it   525069350231428029");
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        static void FindCountForLength(int Length, int[] counts)
        {
            //if (Length == 1)
            //{
            //    result += counts.Count(c => c > 0);
            //    return;
            //}

            for (var i = 0; i < counts.Length; i++)
            {
                if (counts[i] != 0)
                {
                    result++;
                    if (Length > 1)
                    {
                        counts[i]--;
                        FindCountForLength(Length - 1, counts);
                        counts[i]++;
                    }
                }
            }
        }
    }
}
