using System;

namespace CountDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            5. Write a program in C# Sharp to count the number of digits in a number using recursion. Go to the editor
            Test Data :
            Input any number : 12345
            Expected Output :
            The number 12345 contains number of digits : 5 
            */

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CountDigits(n));
        }

        static int CountDigits(int n)
        {
            int count = 0;

            if (n / 10 > 0)
            {
                count += CountDigits(n / 10);
                return count + 1;
            }

            return 1;
        }
    }
}
