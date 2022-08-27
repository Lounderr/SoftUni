using System;

namespace E04.PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];
                Pizza pizza = new Pizza(pizzaName);

                string[] pizzaDough = Console.ReadLine().Split();
                string flour = pizzaDough[1];
                string technique = pizzaDough[2];
                double grams = double.Parse(pizzaDough[3]);

                pizza.Dough = new Dough(flour, technique, grams);

                string[] toppingInfo = Console.ReadLine().Split();
                while (toppingInfo[0] != "END")
                {
                    string toppingType = toppingInfo[1];
                    double toppingGrams = double.Parse(toppingInfo[2]);

                    pizza.AddTopping(new Topping(toppingType, toppingGrams));

                    toppingInfo = Console.ReadLine().Split();
                }

                Console.WriteLine(pizza.ToString());

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
