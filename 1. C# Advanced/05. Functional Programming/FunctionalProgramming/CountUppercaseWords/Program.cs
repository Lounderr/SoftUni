using System;
using System.Linq;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split().Where(word => word != "" && char.IsUpper(word[0])).ToArray();

            foreach (var word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}
