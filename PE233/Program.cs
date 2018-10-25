using System;

namespace PE233
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;

            for (var diameter = 100000000000; diameter > 0; diameter--)
            {
                Console.WriteLine("Diameter: " + diameter);

                var mod1 = 0;
                var mod3 = 0;

                var diameterSquared = 2 * diameter * diameter;
                for (var i = (int) Math.Floor(Math.Sqrt(diameterSquared)); i > 0; i--)
                {
                    if (diameterSquared % i == 0)
                    {
                        if (i % 4 == 1 || diameterSquared / i % 4 == 1)
                        {
                            mod1++;
                            ////Console.WriteLine(i + " Mod 4 == 1");
                        }

                        if (i % 4 == 3 || diameterSquared / i % 4 == 3)
                        {
                            mod3++;
                            ////Console.WriteLine(i + " Mod 4 == 3");
                        }
                    }
                }

                if ((mod1 - mod3) == 105)  // 420 points
                    result += diameter;

                //result = 4 * (mod1 - mod3);
            }
            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
