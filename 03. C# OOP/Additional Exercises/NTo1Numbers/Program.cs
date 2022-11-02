using System;

namespace NTo1Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            2. Write a program in C# Sharp to print numbers from n to 1 using recursion. Go to the editor
            Test Data :
            How many numbers to print : 10
            Expected Output :
            10 9 8 7 6 5 4 3 2 1 
            */

            int n = int.Parse(Console.ReadLine());

            PrintNTo1(n);
        }

        static void PrintNTo1(int num)
        {
            Console.WriteLine(num);
            if (num > 1)
            {
                PrintNTo1(num - 1);
            }
        }
    }
}
