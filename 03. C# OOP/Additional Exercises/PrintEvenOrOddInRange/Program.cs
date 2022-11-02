using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenOrOddInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            6. Write a program in C to print even or odd numbers in a given range using recursion. Go to the editor
            Test Data :
            Input the range to print starting from 1 : 20
            Expected Output :
            All even numbers from 1 to 20 are :
            2 4 6 8 10 12 14 16 18 20  
            */

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());


            Console.WriteLine(new string('-', 5));
            PrintEvenNums(start, end);
            Console.WriteLine(new string('-', 5));
            PrintOddNums(start, end);

        }

        private static void PrintEvenNums(int current, int end)
        {
            if (current <= end)
            {
                if (current % 2 == 0)
                {
                    Console.WriteLine(current);
                }

                PrintEvenNums(current + 1, end);
            }
        }

        private static void PrintOddNums(int current, int end)
        {
            if (current <= end)
            {
                if (current % 2 != 0)
                {
                    Console.WriteLine(current);
                }

                PrintOddNums(current + 1, end);
            }
        }
    }
}
