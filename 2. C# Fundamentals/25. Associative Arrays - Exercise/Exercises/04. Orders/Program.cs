using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            var dict = new Dictionary<string, List<double>>();

            while (!input.Contains("buy"))
            {
                string producName = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (!dict.ContainsKey(producName))
                {
                    dict.Add(producName, new List<double>());
                    dict[producName].Add(price);
                    dict[producName].Add(quantity);
                }
                else
                {
                    dict[producName][1] += quantity;
                    dict[producName][0] = price;
                }

                input = Console.ReadLine().Split().ToArray();
            }

            foreach (var product in dict)
            {
                double totalPrice = product.Value[0] * product.Value[1];
                Console.WriteLine($"{product.Key} -> {totalPrice:F2}");
            }
        }
    }
}
