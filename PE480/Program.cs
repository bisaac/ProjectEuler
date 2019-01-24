using System;
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

            //var phrase = "thereisasyetinsufficientdataforameaningfulanswer";
            var phrase = "aaaaaacdeeeeeeffffghiiiiilmnnnnnorrrssssttttuuwy";

            BigInteger subcount = 1;
            for (var count = 1; count <= 15; count++)
            {
                for (var i = 2; i <= phrase.Length; i++)
                    subcount *= i;
                //for (var i = 2; i <= count; i++)
                //    subcount /= i;
                for (var i = 2; i <= phrase.Length - count; i++)
                    subcount /= i;

                // a
                for (var i = 2; i <= 6; i++)
                    subcount /= i;
                // e
                for (var i = 2; i <= 6; i++)
                    subcount /= i;
                // f
                for (var i = 2; i <= 4; i++)
                    subcount /= i; ;
                // i
                for (var i = 2; i <= 5; i++)
                    subcount /= i;
                // n
                for (var i = 2; i <= 5; i++)
                    subcount /= i;
                // r
                for (var i = 2; i <= 3; i++)
                    subcount /= i; ;
                // s
                for (var i = 2; i <= 4; i++)
                    subcount /= i; ;
                // t
                for (var i = 2; i <= 4; i++)
                    subcount /= i; ;
                // u
                for (var i = 2; i <= 2; i++)
                    subcount /= i; ;

                result += subcount;
            }

            // 525069350231428029

            clock.Stop();
            Console.WriteLine("Is it?: 525069350231428029");
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
