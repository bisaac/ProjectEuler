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

            //var clues = new List<Clue>
            //{
            //    new Clue("1", 0),
            //    new Clue("3", 0),
            //    new Clue("4", 0),
            //    new Clue("7", 1),
            //    new Clue("9", 0)
            //};

            //var clues = new List<Clue>
            //{
            //    new Clue("31", 1),
            //    new Clue("23", 1),
            //    new Clue("24", 1),
            //    new Clue("17", 0),
            //    new Clue("49", 0)
            //};

            //var clues = new List<Clue>
            //{
            //    new Clue("90342", 2),
            //    new Clue("70794", 0),
            //    new Clue("39458", 2),
            //    new Clue("34109", 1),
            //    new Clue("51545", 2),
            //    new Clue("12531", 1)
            //};

            var clues = new List<Clue>
            {
                new Clue("5616185650518293", 2),
                new Clue("3847439647293047", 1),
                new Clue("5855462940810587", 3),
                new Clue("9742855507068353", 3),
                new Clue("4296849643607543", 3),
                new Clue("3174248439465858", 1),
                new Clue("4513559094146117", 2),
                new Clue("7890971548908067", 3),
                new Clue("8157356344118483", 1),
                new Clue("2615250744386899", 2),
                new Clue("8690095851526254", 3),
                new Clue("6375711915077050", 1),
                new Clue("6913859173121360", 1),
                new Clue("6442889055042768", 2),
                new Clue("2321386104303845", 0),
                new Clue("2326509471271448", 2),
                new Clue("5251583379644322", 2),
                new Clue("1748270476758276", 3),
                new Clue("4895722652190306", 1),
                new Clue("3041631117224635", 3),
                new Clue("1841236454324589", 3),
                new Clue("2659862637316867", 2)
            };

            result = SolveClues(clues);

            clock.Stop();
            Console.WriteLine("Answer: " + result);
            Console.WriteLine("Solution took {0} ms", clock.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }

        private static string SolveClues(List<Clue> clues)
        {
            string response = string.Empty;

            for (var i = 0; i < 10; i++)
            {
                response = i.ToString();
                var newClues = new List<Clue>();
                var bFlag = true;
                foreach (var clue in clues)
                {
                    if (bFlag)
                    {
                        var newScore = clue.Score;
                        if (clue.Code[0] == response[0]) newScore--;
                        var newCode = clue.Code.Substring(1);
                        bFlag &= !(newScore < 0);
                        bFlag &= !(newScore > 0 && newCode.Length == 0);
                        if (newCode.Length > 0) newClues.Add(new Clue(newCode, newScore));
                    }
                }

                if (bFlag && newClues.Count == 0)
                    return response;

                if (bFlag && newClues.Count > 0)
                {
                    var nextLevel = SolveClues(newClues);
                    if (nextLevel != string.Empty) return response + nextLevel;
                }
            }

            return string.Empty;
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
