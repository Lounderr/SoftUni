using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using Newtonsoft.Json;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //string input = Console.ReadLine();
            //Console.WriteLine(ImportUsers(context, input));
            //Console.WriteLine(ImportProducts(context, input));
            //Console.WriteLine(ImportCategories(context, input));
            //Console.WriteLine(ImportCategoryProducts(context, input));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var json = File.ReadAllText(inputJson);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var json = File.ReadAllText(inputJson);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var json = File.ReadAllText(inputJson);
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(json);

            foreach (var category in categories)
            {
                if (category.Name != null)
                {
                    context.Categories.Add(category);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var json = File.ReadAllText(inputJson);
            List<CategoryProduct> categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(json);

            foreach (var cp in categoryProducts)
            {
                context.CategoryProducts.Add(cp);
            }

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Select(p => new
            {
                p.Name,
                p.Price,
                Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
            })
                                           .Where(p => p.Price >= 500 && p.Price <= 1000)
                                           .OrderBy(p => p.Price);

            return JsonConvert.SerializeObject(products, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Select(x => new
            {
                x.FirstName,
                x.LastName,
                soldProducts = x.ProductsSold.Select(p => new
                {
                    p.Name,
                    p.Price,
                    BuyerFirstName = p.Buyer.FirstName,
                    BuyerLastName = p.Buyer.LastName
                })
            }).Where(x => x.soldProducts.Count() > 0)
              .OrderBy(x => x.LastName)
              .ThenBy(x => x.FirstName);

            return JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {

            var categories = context.Categories.Select(c => new
            {
                c.Name,
                ProductsCount = c.CategoryProducts.Count,
                AveragePrice = $"{c.CategoryProducts.Select(p => p.Product.Price).Average(x => x):f2}",
                TotalRevenue = $"{c.CategoryProducts.Select(p => p.Product.Price).Sum(x => x):f2}",
            }).OrderByDescending(x => x.ProductsCount);

            return JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }


        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersAndProducts = context.Users.Select(x => new
            {
                x.LastName,
                x.Age,
                SoldProducts = new
                {
                    Products = x.ProductsSold.Select(y => new
                    {
                        y.Name,
                        y.Price
                    }),
                    Count = x.ProductsSold.Select(y => new
                    {
                        y.Name,
                        y.Price
                    }).Count(),
                }
            }).Where(x => x.SoldProducts.Products.Count() > 0)
              .OrderByDescending(x => x.SoldProducts.Products.Count());

            var result = new
            {
                UsersCount = usersAndProducts.Count(),
                Users = usersAndProducts
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

    }
}