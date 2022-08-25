using System;

namespace KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ');
            Action<string[]> print = (names) =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine("Sir " + name);
                }
            };
            print(names);
        }
    }
}
