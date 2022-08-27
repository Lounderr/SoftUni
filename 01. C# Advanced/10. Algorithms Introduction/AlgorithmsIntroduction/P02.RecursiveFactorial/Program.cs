using System;

namespace P02.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(5));
        }

        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
