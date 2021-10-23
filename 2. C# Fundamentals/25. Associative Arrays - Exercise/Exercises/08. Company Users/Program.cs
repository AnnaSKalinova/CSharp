using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] companyInfo = Console.ReadLine().Split(" -> ").ToArray();

            var dict = new SortedDictionary<string, List<string>>();

            while (!companyInfo.Contains("End"))
            {
                string companyName = companyInfo[0];
                string employeeID = companyInfo[1];

                if (!dict.ContainsKey(companyName))
                {
                    dict.Add(companyName, new List<string>());
                }
                if (dict[companyName].All(x => x != employeeID))
                {
                    dict[companyName].Add(employeeID);
                }

                companyInfo = Console.ReadLine().Split(" -> ").ToArray();
            }

            foreach (var company in dict)
            {
                Console.WriteLine($"{company.Key}");

                foreach (var currentID in company.Value)
                {
                    Console.WriteLine($"-- {currentID}");
                }
            }
        }
    }
}
