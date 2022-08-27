using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType = Console.ReadLine();
            while (animalType != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split();

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                try
                {
                    if (animalType == "Dog")
                    {
                        animals.Add(new Dog(name, age, gender));
                    }
                    else if (animalType == "Cat")
                    {
                        if (gender == "Female")
                        {
                            animals.Add(new Kitten(name, age, gender));
                        }
                        else if (gender == "Male")
                        {
                            animals.Add(new Tomcat(name, age, gender));
                        }
                    }
                    else if (animalType == "Frog")
                    {
                        animals.Add(new Frog(name, age, gender));
                    }

                    animalType = Console.ReadLine();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }
}
