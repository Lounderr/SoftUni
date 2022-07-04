using System;
using System.Linq;
using System.Collections.Generic;

namespace Stack_Commands_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] initInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();
            foreach (var num in initInput)
            {
                stack.Push(num);
            }

            string[] cmd;
            while ((cmd = Console.ReadLine().Split(' '))[0].ToLower() != "End")
            {
                if (cmd[0].ToLower() == "add")
                {
                    int[] numsToAdd = cmd.Skip(1).Select(int.Parse).ToArray();
                    foreach (int num in numsToAdd)
                    {
                        stack.Push(num);
                    }
                }

                else if (cmd[0].ToLower() == "remove")
                {
                    for (int i = 0; i < int.Parse(cmd[1]); i++)
                    {
                        stack.Pop();
                    }
                }

                else if (cmd[0].ToLower() == "end")
                {
                    Console.WriteLine(stack.Sum());
                }
            }
        }
    }
}
