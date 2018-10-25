using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    //  M(2,3,100)=96.
    //  M(3,5,100)=75
    //  S(100)=2262

    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            const long N = 10000000;

            var values = Helpers.GenerateLongPrimesBySieve((int)N / 2);

            for (var i = 0; i < values.Count - 1; i++)
            {
                for (var j = i + 1; j < values.Count; j++)
                {
                    long topValue = 0;
                    long baseValue = values[i] * values[j];

                    // process
                    while (baseValue <= N) 
                    {
                        var currentValue = baseValue;
                        while (currentValue <= N)
                        {
                            if (currentValue <= N && topValue < currentValue) topValue = currentValue;
                            currentValue *= values[j];
                        }
                        baseValue *= values[i];
                    }

                    // Console.WriteLine("i: " + values[i] + ", j: " + values[j] + ", topValue: " + topValue);

                    if (topValue > 1)
                    {
                        result += topValue;
                    }
                }
            }
            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }
    }
}
