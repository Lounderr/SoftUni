using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.FoodShortage
{


    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> citizensFood = new Dictionary<string, IBuyer>();
            Dictionary<string, IBuyer> rebelsFood = new Dictionary<string, IBuyer>();


            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);

                if (info.Length == 4)
                {
                    string id = info[2];
                    string birthdate = info[3];
                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    citizensFood[citizen.Name] = citizen;
                }
                else if (info.Length == 3)
                {
                    string group = info[2];
                    Rebel rebel = new Rebel(name, age, group);
                    rebelsFood[rebel.Name] = rebel;
                }
            }
            
            string buyer = Console.ReadLine();
            while (buyer != "End")
            {
                // if name incorrect do nothing
                if (citizensFood.ContainsKey(buyer))
                {
                    citizensFood[buyer].BuyFood();
                }
                else if (rebelsFood.ContainsKey(buyer))
                {
                    rebelsFood[buyer].BuyFood();
                }

                buyer = Console.ReadLine();
            }

            Console.WriteLine(citizensFood.Values.Sum(x => x.Food) + rebelsFood.Values.Sum(x => x.Food));
        }
    }
}
