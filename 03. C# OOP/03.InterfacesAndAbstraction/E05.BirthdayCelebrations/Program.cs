using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.BirthdayCelebrations
{


    internal class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthable = new List<IBirthable>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input[0] == "Robot")
                {
                    string model = input[1];
                    string id = input[2];

                    Robot robot = new Robot(model, id);
                }
                else if (input[0] == "Pet")
                {
                    string name = input[1];
                    string bday = input[2];
                    Pet pet = new Pet(name, bday);
                    birthable.Add(pet);
                }
                else if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string bday = input[4];
                    Citizen citizen = new Citizen(name, age, id, bday);
                    birthable.Add(citizen);
                }

                input = Console.ReadLine().Split();
            }

            string fakesYear = Console.ReadLine();

            List<string> detainedYears = new List<string>();

            foreach (var being in birthable)
            {
                if (being.Birthdate.Split('/', StringSplitOptions.RemoveEmptyEntries)[2] == fakesYear)
                {
                    detainedYears.Add(being.Birthdate);
                }
            }

            foreach (var date in detainedYears)
            {
                Console.WriteLine(date);
            }
        }
    }
}
