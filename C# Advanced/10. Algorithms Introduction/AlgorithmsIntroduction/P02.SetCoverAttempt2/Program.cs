using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SetCoverAttempt2
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
            IList<int[]> matchingSets = new List<int[]>();

            int setsCount = sets.Count;
            for (int i = 0; i < setsCount; i++)
            {
                int[] largestMatchingSet = sets.OrderByDescending(set => set.Count(num => universe.Contains(num))).FirstOrDefault();
                sets.Remove(largestMatchingSet);

                bool matchFound = false;
                foreach (var num in largestMatchingSet)
                {
                    if (universe.Contains(num))
                    {
                        universe.Remove(num);
                        matchFound = true;
                    }
                }

                if (matchFound)
                {
                    matchingSets.Add(largestMatchingSet);
                }
            }

            return matchingSets;
        }
    }
}
