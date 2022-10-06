using System;

namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end]. If an invalid number or a non-number text is entered, the method should throw an exception. Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100. If the user enters an invalid number, make the user enter all of them again.


            // unfinished 

            void ReadNumber(int start, int end)
            {
                for (int i = start; i < end; i++)
                {
                    try
                    {
                        int n = int.Parse(Console.ReadLine());
                        if (n != i)
                        {
                            throw new ArgumentException();
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Invalid input!", e);
                    }
                }
            }

        }
    }
}
