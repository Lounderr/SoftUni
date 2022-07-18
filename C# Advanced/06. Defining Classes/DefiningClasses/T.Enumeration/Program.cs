using System;
using System.Linq;

namespace Enumeration
{
    enum Season // Can't be static
    {
        Spring = 1, Summer = 2, Autumn = 3, Winter = 4
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Season season = Season.Summer;
            Console.WriteLine(season); // Summer
            Console.WriteLine(Season.Winter); // Winter
        }
    }
}
