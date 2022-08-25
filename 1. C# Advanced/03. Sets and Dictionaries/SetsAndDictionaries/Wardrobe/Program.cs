using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                string color = input[0];
                string[] clothes = input[1].Split(',');
                if (wardrobe.ContainsKey(color))
                {
                    foreach (var clothing in clothes)
                    {
                        if (wardrobe[color].ContainsKey(clothing))
                        {
                            wardrobe[color][clothing]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothing, 1);
                        }
                    }
                }
                else
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    foreach (var clothing in clothes)
                    {
                        if (wardrobe[color].ContainsKey(clothing))
                        {
                            wardrobe[color][clothing]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothing, 1);
                        }
                    }
                }
            }
            string[] wantedArr = Console.ReadLine().Split(' ');
            string wantedColor = wantedArr[0];
            string wantedClothing = wantedArr[1];

            foreach ((var color, var clothes) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach (var (item, count) in clothes)
                {
                    Console.Write($"* {item} - {count}");

                    if (color == wantedColor)
                    {
                        if (item == wantedClothing)
                        {
                            Console.Write(" (found!)");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
