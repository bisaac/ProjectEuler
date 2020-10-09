using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using Combinatorics.Collections;

namespace ProjectEuler
{
    class Program
    {
        //static private BigInteger result = 0;

        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();

            // var phrase = "thereisasyetinsufficientdataforameaningfulanswer";
            // var phrase = "aaaaaacdeeeeeeffffghiiiiilmnnnnnorrrssssttttuuwy";
            // var phraseLetters = new char[] { 'a', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'l', 'm', 'n', 'o', 'r', 's', 't', 'u', 'w', 'y' };
            //var letterCounts = new int[] { 6, 1, 1, 6, 4, 1, 1, 5, 1, 1, 5, 1, 3, 4, 4, 2, 1, 1 };
            //var letterCounts = new int[] { 5, 1, 1, 6, 4, 1, 1, 5, 1, 1, 5, 1, 3, 4, 4, 2, 1, 1 };
            ////var phrase = "aabbbcd";
            ////var phraseLetters = new char[] { 'a', 'b', 'c', 'd' };
            ////var letterCounts = new int[] { 2, 3, 1, 1 };

            //var inputSet = phrase.ToCharArray();
            //for (var p = 1; p <= phrase.Length; p++)
            //{
            //    Variations<char> variations = new Variations<char>(inputSet, p, GenerateOption.WithoutRepetition);
            //    Console.WriteLine($"Variations of {{phrase}} choose {p}: size = {variations.Count}");
            //    result += variations.Count;
            //}

            //////result++;
            //////for (var i = 1; i <= phrase.Length; i++)
            ////    for (var i = 1; i <= 2; i++)
            ////        FindCountForLength(i, letterCounts);

            var problem = new Problem();
            problem.Solve();

            clock.Stop();
            //Console.WriteLine("Is it   525069350231428029");
            //Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        //static void FindCountForLength(int Length, int[] counts)
        //{
        //    //if (Length == 1)
        //    //{
        //    //    result += counts.Count(c => c > 0);
        //    //    return;
        //    //}

        //    for (var i = 0; i < counts.Length; i++)
        //    {
        //        if (counts[i] != 0)
        //        {
        //            result++;
        //            if (Length > 1)
        //            {
        //                counts[i]--;
        //                FindCountForLength(Length - 1, counts);
        //                counts[i]++;
        //            }
        //        }
        //    }

        //    //for (var i = 1; i <= 7; i++)
        //    //{
        //    //    BigInteger subTotal = 0;
        //    //    subTotal = Helpers.GetFactorial(7) / Helpers.GetFactorial(i) / Helpers.GetFactorial(7 - i);
        //    //    for (var d = 0; d < counts.Length; d++)
        //    //        subTotal /= Helpers.GetFactorial(counts[d]);
        //    //    Console.WriteLine("Length {i}: {subTotal}");
        //    //    result += subTotal;
        //    //}
        //}
    }

    public class IntegerPartition
    {
        private List<List<BigInteger>> values;

        public IntegerPartition(int max_length)
        {
            values = InitValues(max_length);
        }

        public List<BigInteger> GetValues(int n)
        {
            return values[n];
        }

        private List<List<BigInteger>> InitValues(int max_length)
        {
            //var result = new BigInteger[max_length + 2][];
            //for (var i = 1; i <= max_length + 1; i++)
            //{
            //    result[i] = Generate(i);
            //}
            //return result;

            //var result = new List<BigInteger[]>();
            //result.Append(new BigInteger[0]);
            //for (var i = 1; i <= max_length + 1; i++)
            //{
            //    result.Add(Generate(i));
            //}

            var step = 1;
            var result = new List<List<BigInteger>>();
            foreach (var partition in Generate(step))
                result.Add(partition);
            return result;
        }

        private IEnumerable<List<BigInteger>> Generate(int max_length)
        {
            List<BigInteger> a = new List<BigInteger>();
            for (var i = 0; i < max_length + 1; i++)
                a.Add(0);

            var k = 1;
            a[1] = max_length;
            while (k != 0)
            {
                var x = a[k - 1] + 1;
                var y = a[k] - 1;
                k -= 1;
                while (x <= y)
                {
                    a[k] = x;
                    y -= x;
                    k += 1;
                }
                a[k] = x + y;
                yield return SubList(a, 0, k+1);
            }
        }

        private BigInteger[] SubArray(BigInteger[] a, int index, int length)
        {
            var result = new BigInteger[length];
            Array.Copy(a, index, result, 0, length);
            return result;
        }

        private List<BigInteger> SubList(List<BigInteger> a, int index, int length)
        {
            var result = new List<BigInteger>();
            for (int i = index; i < index + length; i++)
                result.Add(a[i]);
            return result;
        }
    }

    //public class AlphabetCount
    //{
    //    public 
    //}

    public class AlphabeticalOrder
    {
        private Dictionary<char, int> alphabet_order;        private Dictionary<char, int> alphabet_count;

        private int max_length;
        private List<BigInteger> factorial;

        private IntegerPartition partition;


        public AlphabeticalOrder(string phrase, int maxlength)
        {
            //alphabet_count = 0;
            //alphabet_order = 0;
            InitializeAlphabets(phrase);
            max_length = maxlength;
            partition = new IntegerPartition(max_length);
            PopulateFactorialTable(max_length);
            //ways_with_prefix_cache = { '' : 0}

            InitializeAlphabets(phrase);
        }

        internal BigInteger P(string word)
        {
            throw new NotImplementedException();
        }

        internal string W(BigInteger place)
        {
            throw new NotImplementedException();
        }

        private void InitializeAlphabets(string phrase)
        {
            var characters = new List<char>();
            var counts = new List<int>();

            // Get the letters and sort
            foreach (var letter in phrase)
            {
                if (!characters.Contains(letter))
                {
                    characters.Append(letter);
                    counts.Append(0);
                }
            }

            // Count the letters
            foreach (var letter in phrase)
            {
                counts[characters.IndexOf(letter)]++;
            }

            alphabet_count = new Dictionary<char, int>();
            alphabet_order = new Dictionary<char, int>();
            for (var i = 0; i < characters.Count; i++)
            {
                alphabet_count.Add(characters[i], counts[i]);
                alphabet_order.Add(characters[i], counts[i]);
            }
        }

        private void PopulateFactorialTable(int max_length)
        {
            factorial = new List<BigInteger> { new BigInteger(1) };
            for (var i = 1; i <= max_length; i++)
                factorial.Add(i * factorial[i - 1]);
        }
    }

    public class Problem
    {
        private AlphabeticalOrder alphabetical_order;

        public Problem()
        {
            //alphabetical_order = new AlphabeticalOrder("thereisasyetinsufficientdataforameaningfulanswer", 15);
            alphabetical_order = new AlphabeticalOrder("bacbadb", 3);
        }

        public void Solve()
        {
            Test();
            //FindAnswer();
        }

        public void Test()
        {
            //Console.WriteLine(String.Format("{0,20} : {1,20}", "aaaaaacdee", W(10));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", "euler", W(115246685191495243)));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 1, P("a")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 2, P("aa")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 3, P("aaa")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 4, P("aaaa")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 5, P("aaaaa")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 6, P("aaaaaa")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 7, P("aaaaaac")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 8, P("aaaaaacd")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 9, P("aaaaaacde")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 10, P("aaaaaacdee")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 11, P("aaaaaacdeee")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 12, P("aaaaaacdeeee")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 13, P("aaaaaacdeeeee")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 14, P("aaaaaacdeeeeee")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 15, P("aaaaaacdeeeeeef")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 16, P("aaaaaacdeeeeeeg")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 17, P("aaaaaacdeeeeeeh")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 28, P("aaaaaacdeeeeeey")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 29, P("aaaaaacdeeeeef")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 30, P("aaaaaacdeeeeefe")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 115246685191495242, P("euleoywuttttsss")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 115246685191495243, P("euler")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 115246685191495244, P("eulera")));
            //Console.WriteLine(String.Format("{0,20} : {1,20}", 525069350231428029, P("ywuuttttssssrrr")));

            Console.WriteLine(String.Format("{0,7} : {1,10} : {2,10}", "a", 1, P("a")));
            Console.WriteLine(String.Format("{0,7} : {1,10} : {2,10}", "aa", 2, P("aa")));
            Console.WriteLine(String.Format("{0,7} : {1,10} : {2,10}", "aab", 3, P("aab")));
            Console.WriteLine(String.Format("{0,7} : {1,10} : {2,10}", "aac", 4, P("aab")));
            Console.WriteLine(String.Format("{0,7} : {1,10} : {2,10}", "aad", 5, P("aab")));
            Console.WriteLine(String.Format("{0,7} : {1,10} : {2,10}", "ab", 6, P("ab")));
        }

        public void FindAnswer()
        {
            var p = P("legionary") + P("calorimeters") - P("annihilate") + P("orchestrated") - P("fluttering");
            var w = W(p);
            Console.WriteLine("p({0}): {1}", p, w);
        }

        public BigInteger P(string word)
        {
            return alphabetical_order.P(word);
        }

        public string W(BigInteger place)
        {
            return alphabetical_order.W(place);
        }
    }
}
