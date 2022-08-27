using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E04.PizzaCalories
{
    public class Dough
    {
        private readonly IReadOnlyDictionary<string, double> modifierByFlourType = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 }
        };

        private readonly IReadOnlyDictionary<string, double> modifierByBakingTechnique = new Dictionary<string, double>()
        {
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 },
        };

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType.ToLower();
            BakingTechnique = bakingTechnique.ToLower();
            Grams = grams;
            CaloriesPerGram = CalcCaloriesPerGram();
        }

        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (modifierByFlourType.Keys.Contains(value))
                {
                    flourType = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }

        private string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (modifierByBakingTechnique.Keys.Contains(value))
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }

        public double Grams
        {
            get => grams;
            private set
            {
                if (1 <= value && value <= 200)
                {
                    grams = value;
                }
                else
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
            }
        }

        public double CaloriesPerGram { get; set; }

        private double CalcCaloriesPerGram()
        {
            double flourModifier = modifierByFlourType[FlourType];
            double bakingModifier = modifierByBakingTechnique[BakingTechnique];
            return 2 * flourModifier * bakingModifier;
        }
    }
}
