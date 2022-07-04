using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            // I love C#

            Stack<char> stack = new Stack<char>();
            foreach (var c in input)
            {
                stack.Push(c);
            }
            foreach (var c in stack)
            {
                Console.Write(c);
            }

            // When looped through => from bottom to top (first to last added)

        }
    }
}
