using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetCover
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList(); // 1, 2, 3, 4, 5

            List<int[]> sets = new List<int[]>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] set = Console.ReadLine().Split(", ").Select(int.Parse).ToArray(); // 1, 2 // 3, 4 // 5
                sets.Add(set);
            }

            IList<int[]> subsetsOfSet = GetSubsetsOfSet(universe, sets);

            Console.WriteLine($"Sets to take ({subsetsOfSet.Count}):");
            foreach (var set in subsetsOfSet)
            {
                Console.WriteLine("{ " + String.Join(", ", set) + " }");
            }

        }

        public static IList<int[]> GetSubsetsOfSet(IList<int> universe, IList<int[]> sets)
        {
            IList<int[]> setsOrderedByMatches = sets.OrderByDescending(set => set.Count(num => universe.Contains(num))).ToList();
            
            IList<int[]> matchingSets = new List<int[]>();

            foreach (var set in setsOrderedByMatches)
            {
                bool matchFound = false;
                foreach (var num in set)
                {
                    if (universe.Contains(num))
                    {
                        universe.Remove(num);
                        matchFound = true;
                    }
                }
                if (matchFound)
                {
                    matchingSets.Add(set);
                }
            }

            if (universe.Count != 0)
            {
                throw new InvalidOperationException("Error");
            }

            return matchingSets;
        }
    }
}
