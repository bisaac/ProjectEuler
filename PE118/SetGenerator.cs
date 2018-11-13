using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DancingLinks;

namespace ProjectEuler
{
    internal class SetGenerator : DLX
    {
        private List<int> _primes;

        public SetGenerator(List<int> primes)
        {
            _primes = primes;
        }

        public int CreateSets()
        {
            totSolutions = 0;
            // SolveRecurseAndPrint();
            Solve();
            return totSolutions;
        }

        internal void BuildMatrix()
        {
            BuildSkeleton(_primes.Count, 9);

            for (var i = 0; i < _primes.Count; i++)
            {
                AppendRow(BuildPrimeRow(_primes[i]), i);
            }
        }

        internal int[] BuildPrimeRow(int n)
        {
            var digits = new List<int>();

            while (n > 0)
            {
                var d = n % 10;
                digits.Add(d - 1);
                n /= 10;
            }

            return digits.ToArray();
        }

        public override void PrintSolution()
        {
            int[] s = new int[sol.Count];
            IEnumerator ien = sol.GetEnumerator();
            int index = 0;
            while (ien.MoveNext())
            {
                s[index++] = ((Node)ien.Current).Row;
            }
            Array.Sort(s);

            for (int j = 0; j < s.Length; j++)
            {
                Console.Write((_primes[s[j]]).ToString().PadRight(10));
            }
            Console.WriteLine();

        }
    }
}
