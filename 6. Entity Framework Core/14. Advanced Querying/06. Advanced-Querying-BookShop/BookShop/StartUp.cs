namespace BookShop
{
    using System;
    using Data;
    using Initializer;
    using System.Linq;
    using System.Text;
    using BookShop.Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            // Problem 2
            //var command = Console.ReadLine().ToLower();
            //var books = GetBooksByAgeRestriction(db, command);
            //Console.WriteLine(books);

            // Problem 3
            //Console.WriteLine(GetGoldenBooks(db));

            // Problem 4
            //Console.WriteLine(GetBooksByPrice(db));

            // Problem 5
            //var year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));

            // Problem 6
            //var input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            // Problem 7
            //var date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            // Problem 8
            //var input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            // Problem 9
            //var input = Console.ReadLine();
            //console.writeline(getbooktitlescontaining(db, input));

            // Problem 10
            //    var input = Console.ReadLine();
            //    Console.WriteLine(GetBooksByAuthor(db, input));

            // Problem 11
            //var lengthCheck = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db, lengthCheck));

            // Problem 12
            //Console.WriteLine(CountCopiesByAuthor(db));

            // Problem 13
            //Console.WriteLine(GetTotalProfitByCategory(db));

            // Problem 14
            //Console.WriteLine(GetMostRecentBooks(db));

            // Problem 15
            //IncreasePrices(db);

            // Problem 16
            Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var result = context
                .Books
                .ToList()
                .Where(b => b.AgeRestriction.ToString().Equals(command, StringComparison.OrdinalIgnoreCase))
                .Select(b => new
                    {
                        Title = b.Title
                    })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var book in result)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var books = context
                .Books
                .Where(b => b.BookCategories
                    .Any(c => categories.Contains(c.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Date.Date < releaseDate)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            return string.Join(Environment.NewLine, books
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Authors
                .Where(b => b.FirstName
                    .EndsWith(input))
                .Select(b => new
                {
                    FullName = b.FirstName + " " + b.LastName
                })
                .OrderBy(b => b.FullName)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.FullName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Title
                    .ToLower()
                    .Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Author
                    .LastName
                    .ToLower()
                    .StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    Title = b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.Author})"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(a => $"{a.FullName} - {a.TotalCopies}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    Profit = c.CategoryBooks.Select(cb => cb.Book.Price * cb.Book.Copies).Sum(),
                    Name = c.Name
                })
                .OrderByDescending(c => c.Profit)
                .ToList();

            return string.Join(Environment.NewLine, categories.Select(c => $"{c.Name} ${c.Profit:F2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Books = c.CategoryBooks
                        .Select(cb => new
                        {
                            Date = cb.Book.ReleaseDate,
                            Name = cb.Book.Title
                        })
                        .OrderByDescending(b => b.Date)
                        .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Name} ({book.Date.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(books);
            context.SaveChanges();

            return books.Count;
        }
    }
}
