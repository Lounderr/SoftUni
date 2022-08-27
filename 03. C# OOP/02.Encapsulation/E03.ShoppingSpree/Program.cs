using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] peopleInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var personInfo in peopleInfo)
            {
                string[] personNameMoney = personInfo.Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = personNameMoney[0];
                decimal money = decimal.Parse(personNameMoney[1]);

                try
                {
                    people.Add(new Person(name, money));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            List<Product> products = new List<Product>();
            string[] productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var productInfo in productsInfo)
            {
                string[] productNameCost = productInfo.Split("=", StringSplitOptions.RemoveEmptyEntries);

                string name = productNameCost[0];
                decimal cost = decimal.Parse(productNameCost[1]);

                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            string[] cmd = Console.ReadLine().Split();
            while (cmd[0] != "END")
            {
                string personName = cmd[0];
                string productName = cmd[1];

                if (people.Count == 0 || products.Count == 0)
                {
                    cmd = Console.ReadLine().Split();
                    continue;
                }
                Person person = people.Where(p => p.Name == personName).First();

                Product product = products.Where(p => p.Name == productName).First();

                if (person.Money >= product.Cost)
                {
                    person.AddToBag(product);
                    person.Money -= product.Cost;
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }

                cmd = Console.ReadLine().Split();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
