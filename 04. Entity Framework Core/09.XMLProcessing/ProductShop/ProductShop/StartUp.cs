using AutoMapper;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public partial class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            db.Database.EnsureCreated();
            db.Database.Migrate();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ImportUserDto, User>();
                cfg.CreateMap<ImportProductDto, Product>();
                cfg.CreateMap<ImportCategoryDto, Category>();
                cfg.CreateMap<ImportCategoryProductDto, CategoryProduct>();
            });
            mapper = config.CreateMapper();

            var context = new ProductShopContext();
            string inputXml = Console.ReadLine();

            //Console.WriteLine(ImportUsers(context, inputXml)); 
            //Console.WriteLine(ImportCategories(context, inputXml));
            //Console.WriteLine(ImportCategoryProducts(context, inputXml));
            //Console.WriteLine(ImportProducts(context, inputXml));
            //Console.WriteLine(GetProductsInRange(context));
            //Console.WriteLine(GetSoldProducts(context));
            //Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var importUsersDto = (ImportUserDto[])(serializer.Deserialize(File.OpenRead(inputXml)));

            User[] users = mapper.Map<ImportUserDto[], User[]>(importUsersDto);
            context.Users.AddRange(users);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            ImportCategoryDto[] import = ((ImportCategoryDto[])serializer.Deserialize(File.OpenRead(inputXml))).Where(i => i.Name != null).ToArray();

            var importMapped = mapper.Map<ImportCategoryDto[], Category[]>(import);
            context.Categories.AddRange(importMapped);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            ImportProductDto[] import = ((ImportProductDto[])serializer.Deserialize(File.OpenRead(inputXml))).Where(i => i.Name != null).ToArray();

            var importMapped = mapper.Map<ImportProductDto[], Product[]>(import);
            context.Products.AddRange(importMapped);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var import = ((ImportCategoryProductDto[])serializer.Deserialize(File.OpenRead(inputXml)))
                .Where(i =>
                    context.Categories.Any(x => x.Id == i.CategoryId) &&
                    context.Products.Any(x => x.Id == i.ProductId))
                .ToArray();

            var importMapped = mapper.Map<ImportCategoryProductDto[], CategoryProduct[]>(import);
            context.CategoryProducts.AddRange(importMapped);

            return $"Successfully imported {context.SaveChanges()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Select(x => new ExportProductDto
            {
                Name = x.Name,
                Price = x.Price,
                BuyerFullName = x.Buyer.FirstName + " " + x.Buyer.LastName
            }).Where(x => x.Price >= 500 && x.Price <= 1000).OrderBy(x => x.Price).ToArray();

            var serializer = new XmlSerializer(typeof(ExportProductDto[]), new XmlRootAttribute("CategoryProducts"));

            //var fs = File.OpenWrite("openXml.xml");
            //serializer.Serialize(fs, products);
            //fs.Close();
            //return File.ReadAllText("outXml.xml");

            StringWriter strWriter = new StringWriter();

            serializer.Serialize(strWriter, products);

            return strWriter.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users.Select(x => new ExportUserSoldProductsDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                SoldProducts = x.ProductsSold.Select(p => new ExportSoldProductsDto
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToArray()
            }).Where(x => x.SoldProducts.Count() > 0)
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ToArray();

            var serializer = new XmlSerializer(typeof(ExportUserSoldProductsDto[]), new XmlRootAttribute("Users"));

            StringWriter strWriter = new StringWriter();

            serializer.Serialize(strWriter, products);

            return strWriter.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new ExportCategoryDto
                {
                    Name = x.Name,
                    ProductsCount = x.CategoryProducts.Count(),
                    AverageProductPrice = x.CategoryProducts.Average(y => y.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price),
                })
                .OrderByDescending(x => x.ProductsCount)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var serializer = new XmlSerializer(typeof(ExportCategoryDto[]), new XmlRootAttribute("Categories"));

            StringWriter strWriter = new StringWriter();

            serializer.Serialize(strWriter, categories);

            return strWriter.ToString();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
               .Select(x => new ExportUserDto
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Age = x.Age,
                   SoldProducts = new ExportProductCountDto
                   {
                       Count = x.ProductsSold.Count(),
                       Products = x.ProductsSold.Select(p => new ExportProductDto
                       {
                           Name = p.Name,
                           Price = p.Price
                       })
                       .OrderByDescending(p => p.Price)
                       .ToArray()
                   }
               }).ToArray()
                 .Where(x => x.SoldProducts.Count > 0)
                 .OrderByDescending(x => x.SoldProducts.Count)
                 .ToArray();


            var serializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("users"));

            StringWriter strWriter = new StringWriter();

            serializer.Serialize(strWriter, users);

            return strWriter.ToString();
        }
    }
}