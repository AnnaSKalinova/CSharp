using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static string ResultDirectoryPath = "../../../Datasets/Results";
        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();

            // Problem 1
            //string inputJson = File.ReadAllText("../../../Datasets/users.json");
            //var result = ImportUsers(productShopContext, inputJson);

            // Problem 2
            //string inputJson = File.ReadAllText("../../../Datasets/products.json");
            //var result = ImportProducts(productShopContext, inputJson);

            // Problem 3
            //var inputJson = File.ReadAllText("../../../Datasets/categories.json");
            //var result = ImportCategories(productShopContext, inputJson);

            // Problem 4
            //var inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //var result = ImportCategoryProducts(productShopContext, inputJson);

            // Problem 5
            //var result = GetProductsInRange(productShopContext);

            // Problem 6
            //var result = GetSoldProducts(productShopContext);

            // Problem 7
            //var result = GetCategoriesByProductsCount(productShopContext);

            // Problem 8
            var json = GetUsersWithProducts(productShopContext);

            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }

            File.WriteAllText(ResultDirectoryPath + "/users-and-products.json", json);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                .DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert
                .DeserializeObject<CategoryProduct[]>(inputJson);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts
                        .Average(cp => cp.Product.Price)
                        .ToString("F2"),
                    totalRevenue = c.CategoryProducts
                        .Sum(cp => cp.Product.Price)
                        .ToString("F2")
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToArray();

            var result = new
            {
                usersCount = users.Length,
                users = users
            };

            string json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return json;
        }
    }
}