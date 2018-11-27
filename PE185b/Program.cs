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
                new Clue("4895722652190306", 1),
                new Clue("3847439647293047", 1),
                new Clue("8690095851526254", 3),
                new Clue("3174248439465858", 1),
                new Clue("2615250744386899", 2),
                new Clue("2659862637316867", 2),
                new Clue("6375711915077050", 1),
                new Clue("7890971548908067", 3),
                new Clue("6913859173121360", 1),
                new Clue("1748270476758276", 3),
                new Clue("8157356344118483", 1),
                new Clue("2326509471271448", 2),
                new Clue("4513559094146117", 2),
                new Clue("5251583379644322", 2),
                new Clue("5616185650518293", 2),
                new Clue("6442889055042768", 2),
                new Clue("1841236454324589", 3),
                new Clue("3041631117224635", 3),
                new Clue("4296849643607543", 3),
                new Clue("5855462940810587", 3),
                new Clue("9742855507068353", 3)
            };
        }

        private static string SolveClues(List<Clue> clues)
        {
            var incorrectGuesses = new List<char>[16];
            for (var i = 0; i < 16; i++)
                incorrectGuesses[i] = new List<char>();

            foreach (var clue in clues.Where(c => c.Score == 0))
                for (var i = 0; i < clue.Code.Length; i++)
                    incorrectGuesses[i].Add(clue.Code[i]);

            var result = "................";

            return SolveClues(result, incorrectGuesses, clues.Where(c => c.Score > 0).ToList());
        }

        private static string SolveClues(string mask, List<char>[] incorrectGuesses, List<Clue> clues)
        {
            Console.WriteLine(mask);
            if (clues.Count == 0)
            {
                var maskBuilder = new StringBuilder(mask);
                for (var i = 0; i < mask.Length; i++)
                {
                    if (mask[i] != '.') continue;
                    for (var d = '0'; d <= '9'; d++)
                    {
                        if (!incorrectGuesses[i].Contains(d)) maskBuilder[i] = d;
                    }
                }
                return maskBuilder.ToString();
            }

            switch (clues[0].Score)
            {
                case 1:
                    return SolveClueScore1(mask, incorrectGuesses, clues);
                case 2:
                    return SolveClueScore2(mask, incorrectGuesses, clues);
                case 3:
                    return SolveClueScore3(mask, incorrectGuesses, clues);
            }

            return string.Empty;
        }

        private static string SolveClueScore1(string mask, List<char>[] incorrectGuesses, List<Clue> clues)
        {
            Clue clue = clues[0];
            clues.RemoveAt(0);

            for (var i = 0; i < clue.Code.Length; i++)
                incorrectGuesses[i].Add(clue.Code[i]);

            for (var i = 0; i < clue.Code.Length; i++)
            {
                incorrectGuesses[i].Remove(clue.Code[i]);
                if (incorrectGuesses[i].Contains(clue.Code[i]) || (mask[i] != '.' && mask[i] != clue.Code[i]))
                {
                    incorrectGuesses[i].Add(clue.Code[i]);
                    continue;
                }
                var newMask = new StringBuilder(mask) {[i] = clue.Code[i]};
                var result = SolveClues(newMask.ToString(), incorrectGuesses, clues);
                if (result != string.Empty) return result;
            }

            for (var i = 0; i < clue.Code.Length; i++)
                incorrectGuesses[i].Remove(clue.Code[i]);

            clues.Insert(0, clue);

            return string.Empty;
        }

        private static string SolveClueScore2(string mask, List<char>[] incorrectGuesses, List<Clue> clues)
        {
            Clue clue = clues[0];
            clues.RemoveAt(0);

            for (var i = 0; i < clue.Code.Length; i++)
                incorrectGuesses[i].Add(clue.Code[i]);

            for (var i = 0; i < clue.Code.Length - 1; i++)
            {
                incorrectGuesses[i].Remove(clue.Code[i]);
                if (incorrectGuesses[i].Contains(clue.Code[i]) || (mask[i] != '.' && mask[i] != clue.Code[i]))
                {
                    incorrectGuesses[i].Add(clue.Code[i]);
                    continue;
                }
                for (var j = i + 1; j < clue.Code.Length; j++)
                {
                    incorrectGuesses[j].Remove(clue.Code[j]);
                    if (incorrectGuesses[j].Contains(clue.Code[j]) || (mask[j] != '.' && mask[j] != clue.Code[j]))
                    {
                        incorrectGuesses[j].Add(clue.Code[j]);
                        continue;
                    }
                    var newMask = new StringBuilder(mask)
                    {
                        [i] = clue.Code[i],
                        [j] = clue.Code[j]
                    };
                    var result = SolveClues(newMask.ToString(), incorrectGuesses, clues);
                    if (result != string.Empty) return result;
                }
            }

            for (var i = 0; i < clue.Code.Length; i++)
                incorrectGuesses[i].Remove(clue.Code[i]);

            clues.Insert(0, clue);

            return string.Empty;
        }

        private static string SolveClueScore3(string mask, List<char>[] incorrectGuesses, List<Clue> clues)
        {
            Clue clue = clues[0];
            clues.RemoveAt(0);

            for (var i = 0; i < clue.Code.Length; i++)
                incorrectGuesses[i].Add(clue.Code[i]);

            for (var i = 0; i < clue.Code.Length - 2; i++)
            {
                incorrectGuesses[i].Remove(clue.Code[i]);
                if (incorrectGuesses[i].Contains(clue.Code[i]) || (mask[i] != '.' && mask[i] != clue.Code[i]))
                {
                    incorrectGuesses[i].Add(clue.Code[i]);
                    continue;
                }
                for (var j = i + 1; j < clue.Code.Length - 1; j++)
                {
                    incorrectGuesses[j].Remove(clue.Code[j]);
                    if (incorrectGuesses[j].Contains(clue.Code[j]) || (mask[j] != '.' && mask[j] != clue.Code[j]))
                    {
                        incorrectGuesses[j].Add(clue.Code[j]);
                        continue;
                    }
                    for (var k = j + 1; k < clue.Code.Length; k++)
                    {
                        incorrectGuesses[k].Remove(clue.Code[k]);
                        if (incorrectGuesses[k].Contains(clue.Code[k]) || (mask[k] != '.' && mask[k] != clue.Code[k]))
                        {
                            incorrectGuesses[k].Add(clue.Code[k]);
                            continue;
                        }
                        var newMask = new StringBuilder(mask)
                        {
                            [i] = clue.Code[i],
                            [j] = clue.Code[j],
                            [k] = clue.Code[k]
                        };
                        var result = SolveClues(newMask.ToString(), incorrectGuesses, clues);
                        if (result != string.Empty) return result;
                    }
                }
            }

            for (var i = 0; i < clue.Code.Length; i++)
                incorrectGuesses[i].Remove(clue.Code[i]);

            clues.Insert(0, clue);

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
