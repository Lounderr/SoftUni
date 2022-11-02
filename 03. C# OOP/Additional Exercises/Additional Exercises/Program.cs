using System;

namespace Additional_Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            1. Write a program in C# Sharp to print the first n natural number using recursion. Go to the editor
            Test Data :
            How many numbers to print : 10
            Expected Output :
            1 2 3 4 5 6 7 8 9 10 
             */

            int n = int.Parse(Console.ReadLine());
            PrintFirstNNaturalNumbers(n);
        }

        static void PrintFirstNNaturalNumbers(int num)
        {
            if (num > 1)
            {
                PrintFirstNNaturalNumbers(num - 1);
            }

            Console.WriteLine(num);
        }
    }
}
