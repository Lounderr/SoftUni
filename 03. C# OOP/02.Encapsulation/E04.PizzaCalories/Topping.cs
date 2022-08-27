using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E04.PizzaCalories
{
    public class Topping
    {
        private readonly IReadOnlyDictionary<string, double> modifierByToppingType = new Dictionary<string, double>()
        {
            {"Meat", 1.2 },
            {"Veggies", 0.8 },
            {"Cheese", 1.1 },
            {"Sauce", 0.9 },
        };

        private string toppingType;
        private double grams;

        public Topping(string toppingType, double grams)
        {
            ToppingType = toppingType.ToUpper()[0] + toppingType.Substring(1).ToLower();

            Grams = grams;
            CaloriesPerGram = CalcCaloriesPerGram();
        }

        private string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (modifierByToppingType.Keys.Contains(value))
                {
                    toppingType = value;
                }
                else
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
            }
        }

        public double Grams
        {
            get => grams;
            private set
            {
                if (1 <= value && value <= 50)
                {
                    grams = value;
                }
                else
                {
                    throw new Exception($"{toppingType} weight should be in the range [1..50]."); // !
                }
            }
        }

        public double CaloriesPerGram { get; set; }

        private double CalcCaloriesPerGram()
        {
            double toppingTypeModifier = modifierByToppingType[ToppingType];
            return 2 * toppingTypeModifier;
        }
    }
}
