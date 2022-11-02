using System;

namespace FindSumOfNNaturalNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            3. Write a program in C# Sharp to find the sum of first n natural numbers using recursion. Go to the editor
            Test Data :
            How many numbers to sum : 10
            Expected Output :
            The sum of first 10 natural numbers is : 55 
            */

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSumOfNNaturalNums(n));
        }

        static int GetSumOfNNaturalNums(int n)
        {
            int sum = 0;

            if (n > 0)
            {
                sum += GetSumOfNNaturalNums(n - 1);
                return n + sum;
            }

            return 0; // 0!
        }
    }
}
