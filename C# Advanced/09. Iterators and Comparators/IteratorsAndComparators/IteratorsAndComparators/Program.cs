using System;

namespace IteratorsAndComparators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? a = 1;
            a ??= 0;
            Console.WriteLine(a);
            // The same as
            if (a == null)
            {
                a = 0;
            }
            Console.WriteLine(a);
        }
    }
}
