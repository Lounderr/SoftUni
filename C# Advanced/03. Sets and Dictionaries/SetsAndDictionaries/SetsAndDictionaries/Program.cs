using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SetsAndDictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tuples
            (int fValue, int sValue)[] valuePairs = new (int, int)[3]
            {
                (1, 2),
                (3, 4),
                (5, 6),
            };
            
            foreach (var (fValue, sValue) in valuePairs)
            {
                Console.WriteLine(fValue);
                Console.WriteLine(sValue);
            }
        }
    }
}
