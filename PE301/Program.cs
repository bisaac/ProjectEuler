using System;

namespace PE301
{
    class Program
    {
        // 2178309 turns out to be the 30th number in the Fibonacci sequence

        static void Main(string[] args)
        {
            int result = 0;

            for (int i = 1; i <= Math.Pow(2,30); i++)
            {
                if (Convert.ToString(i, 2).Contains("11")) continue;
                result++;
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
