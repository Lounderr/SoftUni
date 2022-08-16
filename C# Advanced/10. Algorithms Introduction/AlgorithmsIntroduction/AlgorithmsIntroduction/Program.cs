using System;

namespace AlgorithmsIntroduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Recursion());
        }
        public static int Recursion(string s = "O", int depth = 1) // n = 1
        {
            if (s.Length == 5)
            {
                return 10;
            }
            Console.WriteLine($"On depth {depth} - During recursion: {s} ");

            Recursion(s + "O", depth + 1);

            Console.WriteLine($"On depth {depth} - After  recursion: {s} ");

            return 100;
        }
    }
}
