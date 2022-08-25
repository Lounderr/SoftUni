using System;
using System.Collections.Generic;

namespace NestedDictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Bulgaria, Sofia, 10 000
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();
            dictionary.Add("Bulgaria", new Dictionary<string, int>() { { "Plovdiv", 100 } });
            dictionary["Bulgaria"].Add("Sofia", 200);

            dictionary["Bulgaria"]["Sofia"] = 10000;
        }
    }
}
