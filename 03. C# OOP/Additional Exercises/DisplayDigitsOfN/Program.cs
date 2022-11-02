using System;

namespace DisplayDigitsOfN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            DisplayDigits(n);
        }

        static void DisplayDigits(int n)
        {
            if (n / 10 > 0)
            {
                DisplayDigits(n / 10);
                Console.WriteLine(n % 10);
            }
            else
            {
                Console.WriteLine(n);
            }
        }
    }
}
