using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // sequence white 1 2 3 [4]
            // sequence gray [1] 2 3 4

            // WHILE w == 0 OR g == 0
            // compare last white to first gray 
            // if (w == g) =>
            // // if (w + g IN [area]ByLocation) => remove w and g from sequences AND add to dict<location, count> tilesByLocation
            // // else => add to dict<location, count> tilesByLocation WHERE location = Floor
            // else => (w = w / 2 AND insert back into sequence (same position)) AND (put g at the back of the sequence)
            // Print g and w tiles left
            // Print tiles for each location

            Dictionary<string, int> areaByLocation = new Dictionary<string, int>()
            {
                { "Sink", 40 },
                { "Oven", 50 },
                { "Countertop", 60 },
                { "Wall", 70 }
            };

            Dictionary<string, int> tilesByLocation = new Dictionary<string, int>();

            Stack<int> whites = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> grays = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            while (whites.Count > 0 && grays.Count > 0)
            {
                int w = whites.Peek();
                int g = grays.Peek();

                if (w == g)
                {
                    if (areaByLocation.ContainsValue(w + g))
                    {
                        string location = areaByLocation.FirstOrDefault(x => x.Value == w + g).Key;

                        if (tilesByLocation.ContainsKey(location))
                        {
                            tilesByLocation[location]++;
                        }
                        else
                        {
                            tilesByLocation[location] = 1;
                        }

                        whites.Pop();
                        grays.Dequeue();
                    }
                    else
                    {
                        string location = "Floor";

                        if (tilesByLocation.ContainsKey(location))
                        {
                            tilesByLocation[location]++;
                        }
                        else
                        {
                            tilesByLocation[location] = 1;
                        }
                        whites.Pop();
                        grays.Dequeue();
                    }
                }
                else
                {
                    whites.Push(whites.Pop() / 2);
                    grays.Enqueue(grays.Dequeue());
                }
            }

            if (whites.Count == 0)
            {
                Console.WriteLine($"White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {String.Join(", ", whites)}");
            }

            if (grays.Count == 0)
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {String.Join(", ", grays)}");
            }

            foreach (var kvp in tilesByLocation.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
            {
                string location = kvp.Key;
                int tilesCount = kvp.Value;

                Console.WriteLine($"{location}: {tilesCount}");
            }


        }
    }
}
