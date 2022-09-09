using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.BorderControl
{


    internal class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> beings = new List<IIdentifiable>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                // citizen "{name} {age} {id}" 
                // robot   "{model} {id}"  
                if (input.Length == 2)
                {
                    string model = input[0];
                    string id = input[1];

                    Robot robot = new Robot(model, id);
                    beings.Add(robot);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    Citizen citizen = new Citizen(name, age, id);
                    beings.Add(citizen);
                }

                input = Console.ReadLine().Split();
            }

            string fakesDigits = Console.ReadLine();

            List<string> detainedIds = new List<string>();

            foreach (var being in beings)
            {
                if (being.Id.Substring(being.Id.Length - fakesDigits.Length) == fakesDigits)
                {
                    detainedIds.Add(being.Id);
                }
            }

            foreach (var id in detainedIds)
            {
                Console.WriteLine(id);
            }
        }
    }
}
