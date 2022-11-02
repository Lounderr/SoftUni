using System;

namespace PalindromeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            8. Write a program in C# Sharp to check whether a given string is Palindrome or not using recursion. Go to the editor
            Test Data :
            Input a string : RADAR
            Expected Output :
            The string is Palindrome.
            */

            string word = "1234";
            Console.WriteLine(ReverseLetters(word));
        }

        private static string ReverseLetters(string word)
        {
            int len = word.Length;
            string substr = word.Substring(1);
            char firstChar = word[0];


            if (len <= 1)
            {
                return word;
            }

            return ReverseLetters(substr) + firstChar;
        }
    }
}
