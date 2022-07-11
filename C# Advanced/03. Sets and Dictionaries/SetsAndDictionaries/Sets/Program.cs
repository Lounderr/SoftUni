using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>()
            {
                "Jeff",
                "Harry",
                "Jeb",
            };
            set.Add("Unique name");
            set.Add("Unique name");
            if (set.Contains("Jeb"))
            {
                set.Remove("Jeb");
            }
            Console.WriteLine(set.First());
            set.Clear();
        }
    }
}
