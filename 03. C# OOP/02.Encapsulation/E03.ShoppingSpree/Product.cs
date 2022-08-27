using System;

namespace E03.ShoppingSpree
{
    class Product
    {
        private decimal cost;
        private string name;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => name; 
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Cost
        {
            get => cost; 
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                cost = value;
            }
        }
    }
}
