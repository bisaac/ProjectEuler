using System;
using System.Runtime.CompilerServices;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            const int numShuffles = 60;

            long possibilities = 1;
            for (long i = 1; i <= numShuffles; i++) possibilities *= 2;

            var factors = Helpers.GetFactors(possibilities - 1);
            factors.Sort();

            foreach (var deckSize in factors)
            {
                if (deckSize == 1) continue;
                long shuffles = 1;
                bool flag = false;
                var i = 0;
                while (!flag)
                {
                    shuffles *= 2;
                    flag = shuffles % deckSize == 1;
                    i++;
                }

                if (i == numShuffles) result += deckSize + 1;
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
