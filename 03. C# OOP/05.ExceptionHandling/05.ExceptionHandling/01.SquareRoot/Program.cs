using System;

namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a program that reads an integer number and calculates and prints its square root.If the number is invalid or negative, print "Invalid number".In all cases finally print "Goodbye".Use try-catch-finally.

            int n = int.Parse(Console.ReadLine());
            string result = Math.Sqrt(n).ToString();
            try
            {
                if (result == "NaN" || result == "0")
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}
