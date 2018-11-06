using System;

namespace ProjectEuler
{
    class Program
    {
        private static int[,] _transitions;

        static void Main(string[] args)
        {
            long result = 0;

            var A = 10000000;
            var B = 20000000;

            //var A = 1;
            //var B = 100;

            var primes = Helpers.GeneratePrimeSieve(B);

            _transitions = FindTransitionDeltas();

            for (var i = A; i <= B; i++)
            {
                if (primes[i])
                {
                    //Console.WriteLine("{0} : {1}", i, CalculateTransition(i));
                    result += CalculateTransition(i);
                }
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static int CalculateTransition(int fromNum)
        {
            if (fromNum >= 1 && fromNum <= 9) return 0;
            return CalculateTransition(fromNum, DigitalRoot(fromNum));
        }

        private static int CalculateTransition(int fromNum, int toNum)
        {
            var tempNum = toNum;
            var value = 0;
            while (tempNum > 0)
            {
                value += _transitions[fromNum % 10, tempNum % 10];
                fromNum /= 10;
                tempNum /= 10;
            }

            if (toNum <= 9) return value;
            return value + CalculateTransition(toNum, DigitalRoot(toNum));
        }

        private static int DigitalRoot(int n)
        {
            var value = 0;
            while (n > 9)
            {
                value += n % 10;
                n /= 10;
            }

            return value + n;
        }

        private static int[,] FindTransitionDeltas()
        {
            var leds = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 0}, {0, 1, 1, 0, 0, 0, 0}, {1, 1, 0, 1, 1, 0, 1}, {1, 1, 1, 1, 0, 0, 1},
                {0, 1, 1, 0, 0, 1, 1}, {1, 0, 1, 1, 0, 1, 1}, {1, 0, 1, 1, 1, 1, 1}, {1, 1, 1, 0, 0, 1, 0},
                {1, 1, 1, 1, 1, 1, 1}, {1, 1, 1, 1, 0, 1, 1}
            };

            var transition = new int[10, 10];

            for (var f = 0; f < 10; f++)
            {
                for (var t = 0; t < 10; t++)
                {
                    var value = 0;
                    for (var l = 0; l < 7; l++)
                    {
                        value += (leds[f, l] + leds[t, l]);
                        if (leds[f, l] != leds[t, l])
                            value--;
                    }
                    transition[f, t] = value;
                }
            }

            return transition;
        }
    }
}
