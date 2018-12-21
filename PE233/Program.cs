using System;

namespace PE233
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                f(1328125) = 180
                f(84246500) = f(248431625) = 420

                30875234922 for n<=38000000

                271204031455541300
                for n<=10^10 i have 2709499279563106.
                is it correct?
                Unfortunately, it's not.
                You aren't the first one to get this particular result, though.
                Yeah, you're on the right track, but are missing something that a lot of other people missed initially too.

                Look at the definition given for f(N)

                There are 5422629 solutions in total and there is no difference between even and odd N. It's something else

                38000000 is significantly less than 10^11.
                That's the only significance of 38000000.

                Think I just had my epiphany, having to do with the completeness of my 3(mod4) list
             */

            long result = 0;

            //for (long N = 1; N <= 100000000000; N++)
            for (long N = 1; N <= 38000000; N++)
            //for (long N = 248431625; N <= 248431625; N++)
            {
                //Console.WriteLine("Diameter: " + N);

                var mod1 = 0;
                var mod3 = 0;

                var diameterSquared = 2 * N * N;
                for (long i = 1; i * i <= diameterSquared; i++)
                {
                    if (diameterSquared % i == 0)
                    {
                        if (i % 4 == 1 || diameterSquared / i % 4 == 1)
                        {
                            mod1++;
                            //Console.WriteLine(i + " Mod 4 == 1");
                        }

                        if (i % 4 == 3 || diameterSquared / i % 4 == 3)
                        {
                            mod3++;
                            //Console.WriteLine(i + " Mod 4 == 3");
                        }
                    }
                }

                //Console.WriteLine("Diameter: {3}, Mod1: {0}, Mod3: {1}, Result: {2}", mod1, mod3, 4 * (mod1 - mod3), N);

                // (420 - 4) / 8 = 104

                if ((mod1 - mod3) == 105)  // 420 points
                    result += N;

                //result = 4 * (mod1 - mod3);
            }
            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
