using System;
using System.Linq;

namespace P03.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            string[] cmds = Console.ReadLine().Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            while (cmds[0] != "END")
            {
                if (cmds[0] == "Push")
                {
                    int[] items = cmds.Skip(1).Select(int.Parse).ToArray();
                    stack.Push(items);
                }
                else if (cmds[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                cmds = Console.ReadLine().Split();
            }

            Console.WriteLine(stack.ToString());
        }
    }
}
