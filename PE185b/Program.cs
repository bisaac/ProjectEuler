using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = Stopwatch.StartNew();
            string result = string.Empty;

            var clues = GetClues();

            result = SolveClues(clues);

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static List<Clue> GetClues()
        {
            return new List<Clue> {
                new Clue("2321386104303845", 0),
                new Clue("3847439647293047", 1),
                new Clue("3174248439465858", 1),
                new Clue("4895722652190306", 1),
                new Clue("6375711915077050", 1),
                new Clue("6913859173121360", 1),
                new Clue("8157356344118483", 1),
                new Clue("2326509471271448", 2),
                new Clue("2615250744386899", 2),
                new Clue("2659862637316867", 2),
                new Clue("4513559094146117", 2),
                new Clue("5251583379644322", 2),
                new Clue("5616185650518293", 2),
                new Clue("6442889055042768", 2),
                new Clue("1748270476758276", 3),
                new Clue("1841236454324589", 3),
                new Clue("3041631117224635", 3),
                new Clue("4296849643607543", 3),
                new Clue("5855462940810587", 3),
                new Clue("7890971548908067", 3),
                new Clue("8690095851526254", 3),
                new Clue("9742855507068353", 3)
            };
        }

        private static string SolveClues(List<Clue> clues)
        {
            var zeroClue = clues.First(c => c.Score == 0).Code;
            var result = "................";

            return SolveClues(result, zeroClue, clues.Where(c => c.Score > 0).ToList());
        }

        private static string SolveClues(string mask, string zeroClue, List<Clue> list)
        {
            string result = string.Empty;

            switch (list[0].Score)
            {
                case 1:
                    result = "1";
                    break;
                case 2:
                    result = "2";
                    break;
                case 3:
                    result = "3";
                    break;
            }

            return result;
        }
    }

    class Clue
    {
        public string Code { get; set; }
        public int Score { get; set; }
        public Clue(string code, int score)
        {
            Code = code;
            Score = score;
        }
    }
}
