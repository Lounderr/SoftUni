using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{
    internal class Program
    {
        static void Main()
        {
            Action writeHelloWorld = WriteHelloWorld;
            Func<long> getTicks = GetTicks;
            Func<int, long> multiplySelf = MultiplySelf;
            Func<int, int, long> multiply = Multiply;

            writeHelloWorld();
            Console.WriteLine(multiplySelf(4));
            PrintResult(multiply, 2, 3);
            PrintResult(Multiply, 3, 4);
            PrintSefMultiplyLoop(2, 4, multiplySelf);

            List<string> list = new List<string>();
            list.Add("a");
            list.Add("c");
            list.Add("b");
            list.Add("c");

            Console.WriteLine(String.Join(' ', list.Where(LetterIsC)));
            Console.WriteLine(String.Join(' ', list.Where((string x) => x == "a")));
            Console.WriteLine(String.Join(' ', list.Where(x => x == "a"))); // => goes to

            int[] arr = new int[] { 4, 5, 6, 7, 8 };
            Console.WriteLine(String.Join(' ', arr.Where<int>((_, y) => y % 2 == 0)));


            var numbers = Enumerable.Range(1, 100);
            IEnumerable<IGrouping<int, int>> groups = numbers.GroupBy(x => x.ToString().Length); // 1...9 | 10...99 | 100
            foreach (var group in groups)
            {
                Console.WriteLine(group.Key + " --> " + group.First() + " - " + group.Last() + " # " + group.Sum());
            }

            var nums = Enumerable.Range(1, 5);

            Console.WriteLine(nums.Aggregate(/*initial*/1, (/*acc-ing num*/curr, x/*num-from-nums (increasing)*/) => curr * x));
            /*
            1 * 1
            1 * 2
            2 * 3
            6 * 4
            24 * 5
            120
            */

            char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f' };
            Console.WriteLine(chars.Aggregate("", (curr, c) => curr + c));
            Console.WriteLine(chars.Aggregate("", (curr, c) => curr += c));
        }

        static void PrintSefMultiplyLoop(int a, int length, Func<int, long> multiplySelf)
        {
            for (int i = 0; i < length; i++)
            {
                a = (int)multiplySelf(a);
            }
            Console.WriteLine(a);
        }
        static void PrintResult(Func<int, int, long> multiply, int a, int b) // Функция от по-висок ред / Function of higher order
        {
            Console.WriteLine(multiply(a, b));
        }
        static void WriteHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
        static long GetTicks()
        {
            return DateTime.Now.Ticks;
        }
        static long MultiplySelf(int a)
        {
            return a * a;
        }
        static long Multiply(int a, int b)
        {
            return a * b;
        }
        static bool LetterIsC(string x) => x == "c";
    }
}
