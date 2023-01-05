namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            int command = int.Parse(Console.ReadLine());

            Console.WriteLine(GetTotalProfitByCategory(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            string output = String.Join(Environment.NewLine, context.Books
                .Where(x => x.AgeRestriction == (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command.ToUpper()[0] + command.Substring(1).ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList()
            );

            return output;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string output = String.Join(Environment.NewLine, context.Books
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    x.Copies,
                    x.EditionType
                })
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList()
                );

            return output;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            string output = String.Join(Environment.NewLine, context.Books
                .Select(x => new { x.Title, x.Price })
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => $"{x.Title} - ${x.Price:f2}")
                .ToList()
            );

            return output;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string output = String.Join(Environment.NewLine, context.Books
                .Select(x => new { x.BookId, x.ReleaseDate, x.Title, x.Price })
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList()
            );

            return output;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string output = String.Join(Environment.NewLine, context.Books
                .Select(x => new
                {
                    x.Title,
                    Categories = x.BookCategories
                        .Select(x => x.Category.Name.ToLower())
                        .ToList()
                })
                .ToList()
                .Where(x => x.Categories.All(y => categories.Contains(y)))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList()
            );

            return output;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            //Return the title, edition type and price of all books that are released before a given date. The date will be a string in the format dd-MM-yyyy.
            //Return all of the rows in a single string, ordered by release date descending.

            string output = String.Join(Environment.NewLine, context.Books
                .Select(x => new { x.Title, x.EditionType, x.Price, x.ReleaseDate })
                .Where(x => x.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .Select(x => new { x.ReleaseDate, TitlePrice = $"{x.Title} - {x.EditionType} - ${x.Price}" })
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => x.TitlePrice)
                .ToList()
            );

            return output;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string output = String.Join(Environment.NewLine, context.Authors
                .Select(x => new { FullName = x.FirstName + " " + x.LastName, x.FirstName })
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FullName)
                .ToList()
            );

            return output;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string output = String.Join(Environment.NewLine, context.Books
                .Select(x => x.Title)
                .Where(x => x.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x)
                .ToList()
            );

            return output;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string output = String.Join(Environment.NewLine, context.Books
                .Select(x => new { x.BookId, x.Title, x.Author.FirstName, x.Author.LastName, })
                .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.FirstName} {x.LastName})")
                .ToList()
            );

            return output;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
            => context.Books.Select(x => x.Title).Count(x => x.Length > lengthCheck);

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            string output = String.Join(Environment.NewLine, context.Authors
                .Select(x => new { FullName = x.FirstName + " " + x.LastName, BookCopies = x.Books.Select(x => x.Copies).Sum() })
                .OrderByDescending(x => x.BookCopies)
                .Select(x => $"{x.FullName} {x.BookCopies}")
                .ToList()
            );

            return output;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            string output = String.Join(Environment.NewLine, context.BooksCategories
                .Select(x => new { x.Category.Name, Profit = x.Book.Price * x.Book.Copies })
                .ToList()
                .GroupBy(x => x.Name)
                .Select(x => new { x.Key, Profit = x.Sum(x => x.Profit) })
                .OrderByDescending(x => x.Profit)
                .Select(x => $"{x.Key} ${x.Profit:f2}")
                .ToList()
            );

            return output;
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks
                                .Select(cb => new
                                {
                                    BookTitle = cb.Book.Title,
                                    BookReleaseDate = cb.Book.ReleaseDate
                                }).OrderByDescending(b => b.BookReleaseDate).Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categories)
            {
                output.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    output.AppendLine($"{book.BookTitle} ({book.BookReleaseDate.Value.Year})");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToUpdate = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context.Books
                .Where(x => x.Copies < 4200);

            int count = booksToDelete.Count();

            foreach (var book in booksToDelete)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return count;
        }
    }
}
