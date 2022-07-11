using System;
using System.Collections.Generic;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> charOccurances = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (charOccurances.ContainsKey(text[i]))
                {
                    charOccurances[text[i]]++;
                }
                else
                {
                    charOccurances.Add(text[i], 1);
                }
            }
            foreach (var charOcc in charOccurances)
            {
                Console.WriteLine($"{charOcc.Key}: {charOcc.Value} time/s");
            }
        }
    }
}
