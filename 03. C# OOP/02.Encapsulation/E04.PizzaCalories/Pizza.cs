using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.PizzaCalories
{
    public class Pizza
    {
        private List<Topping> toppings;
        private Dough dough;
        private string name;

        public Pizza(string name)
        {
            Name = name;

            toppings = new List<Topping>();
            ToppingsCount = 0;
        }

        public Dough Dough
        {
            get => dough;
            set
            {
                dough = value;
            }
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public int ToppingsCount { get; private set; } // !

        public double TotalCalories { get; private set; }

        private double CalcTotalCalories()
        {
            return toppings.Sum(t => t.CaloriesPerGram * t.Grams) + Dough.CaloriesPerGram * Dough.Grams;
        }

        public void AddTopping(Topping topping)
        {
            if (ToppingsCount == 10)
            {
                throw new Exception($"Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);

            ToppingsCount = toppings.Count;
            TotalCalories = CalcTotalCalories();
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
