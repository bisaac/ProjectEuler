using System;
using System.Text.RegularExpressions;

namespace PE206
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            long num = 138902663;

            var mask = "1.2.3.4.5.6.7.8.9";
            var check = new Regex(mask);
            bool found = false;

            while (!found && num > 101010101)
            {
                num -= 2;
                var numsq = num * num;
                found = check.IsMatch(numsq.ToString());
            }

            Console.WriteLine("Answer: " + num + "0");
            //Console.ReadLine();
        }
    }
}
