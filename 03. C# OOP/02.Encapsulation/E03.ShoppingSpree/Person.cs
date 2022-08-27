using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E03.ShoppingSpree
{
    class Person
    {
        public List<Product> bagOfProducts;
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
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

        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                money = value;
            }
        }

        public void AddToBag(Product product)
        {
            bagOfProducts.Add(product);
        }

        public override string ToString()
        {
            if (bagOfProducts.Count > 0)
            {
                return $"{Name} - {String.Join(", ", bagOfProducts.Select(x => x.Name))}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }
    }
}
