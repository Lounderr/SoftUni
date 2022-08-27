using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace P01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
            {
            // input - sequence (steel)
            // input - sequence (carbon)

            // steel.First mix with carbon.Last
            // if sum(sf, cl) == swords table => forge => remove resources from sequences otherwise remove only steel and carbon+5

            Dictionary<string, int> resourcesBySwords = new Dictionary<string, int>()
            {
                { "Gladius", 70 },
                { "Shamshir", 80 },
                { "Katana", 90 },
                { "Sabre", 110 },
                { "Broadsword", 150 }
            };

            Dictionary<string, int> forgesBySwords = new Dictionary<string, int>();

            Stack<int> steel = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).Reverse());
            LinkedList<int> carbon = new LinkedList<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int sf = steel.Peek();
                int cl = carbon.Last();

                if (resourcesBySwords.ContainsValue(sf + cl))
                {
                    string swordName = resourcesBySwords.FirstOrDefault(x => x.Value == sf + cl).Key;
                    if (forgesBySwords.ContainsKey(swordName))
                    {
                        forgesBySwords[swordName]++;
                    }
                    else
                    {
                        forgesBySwords[swordName] = 1;
                    }

                    steel.Pop();
                    carbon.RemoveLast();
                }
                else
                {
                    steel.Pop();
                    int last = carbon.Last();
                    carbon.RemoveLast();
                    carbon.AddLast(last + 5);

                }

            }

            if (forgesBySwords.Count > 0)
            {
                Console.WriteLine($"You have forged {forgesBySwords.Sum(x => x.Value)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine("Steel left: " + String.Join(", ", steel));
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine("Carbon left: " + String.Join(", ", carbon.Reverse()));
            }

            foreach (var forgesBySword in forgesBySwords.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{forgesBySword.Key}: {forgesBySword.Value}");
            }
        }
    }
}
