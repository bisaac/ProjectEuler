using System;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;

            int elementCount = 12;
            long limit = (long) Math.Pow(3, elementCount);  // 531441      4 => 1; 7 => 70

            for (long i = 0; i < limit; i++)
            {
                var triString = ConvertToTrinary(i);
                if (triString[0] == '2') continue;

                triString = new string('0',elementCount - triString.Length) + triString;

                if (triString.Count(x => x == '1') != triString.Count(x => x == '2')) continue;
                // if (triString.Count(x => x == '1') % 2 != 0) continue;

                var direction = 0;
                var gFlag = 0;
                var lFlag = 0;
                for (var c = 0; c < triString.Length; c++)
                {
                    if (triString[c] == '1') direction++;
                    if (triString[c] == '2') direction--;
                    if (gFlag < direction) gFlag = direction;
                    if (lFlag > direction) lFlag = direction;
                }

                //if (gFlag == 0 || lFlag == 0) continue;
                if (lFlag == 0) continue;

                //Console.WriteLine(i + " ---> " + triString + " ---> " + lFlag + ":" + gFlag);

                result++;
            }

            Console.WriteLine("Answer: " + result);
            Console.ReadLine();
        }

        private static string ConvertToTrinary(long n)
        {
            if (n == 0) return "0";
            StringBuilder sb = new StringBuilder();
            while (n > 0)
            {
                sb.Insert(0, n % 3);
                n /= 3;
            }

            return sb.ToString();
        }
    }
}
