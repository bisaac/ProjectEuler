using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;

            //Console.WriteLine("H(3) --> 1: " + H(3));
            //Console.WriteLine("H(6) --> 12: " + H(6));
            //Console.WriteLine("H(20) --> 966: " + H(20));

            for (var i = 3; i <= 12345; i++)
                result += H(i);

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static long H(int n)
        {
            long countLatticePoints = (n + 1) * (n + 2) / 2L;
            int largest = n / 3;
            long count = 0L;

            for (int i = 1; i <= largest; i++)
            {
                countLatticePoints -= 3 * (n - 3 * (i - 1));
                count += i * countLatticePoints;
            }

            return count;
        }
    }
}
