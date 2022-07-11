using System;
using System.Collections.Generic;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            string storeName = "";
            string productName = "";
            double price = 0;

            SortedDictionary<string, Dictionary<string, double>> stores = new();
            while (true)
            {
                input = Console.ReadLine().Split(", ");

                if (input[0] == "Revision")
                {
                    break;
                }

                storeName = input[0];
                productName = input[1];
                price = double.Parse(input[2]);

                if (!stores.ContainsKey(storeName))
                {
                    stores.Add(storeName, new Dictionary<string, double>());
                    stores[storeName].Add(productName, price);
                }
                else
                {
                    stores[storeName].Add(productName, price);
                }
            }
            foreach (var store in stores)
            {
                Console.WriteLine($"{store.Key}->");
                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
