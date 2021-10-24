using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int totalCalories = 0;
            int countOfDaysWithFood = 0;

            string pattern = @"(\||#)([A-Za-z ]+)(\1)([\d]{2}\/[\d]{2}\/[\d]{2})(\1)(\d+)(\1)";

            Regex regex = new Regex(pattern);

            foreach (Match match in Regex.Matches(text, pattern))
            {
                int currrentCalories = int.Parse(match.Groups[6].Value);
                totalCalories += currrentCalories;
            }

            if (totalCalories == 0)
            {
                countOfDaysWithFood = 0;
            }
            else
            {
                countOfDaysWithFood = totalCalories / 2000;
            }

            Console.WriteLine($"You have food to last you for: {countOfDaysWithFood} days!");

            foreach (Match match in Regex.Matches(text, pattern))
            {
                int currrentCalories = int.Parse(match.Groups[6].Value);
                string itemName = match.Groups[2].Value;
                string expirationDate = match.Groups[4].Value;

                Console.WriteLine($"Item: {itemName}, Best before: {expirationDate}, Nutrition: {currrentCalories}");
            }
        }
    }
}
