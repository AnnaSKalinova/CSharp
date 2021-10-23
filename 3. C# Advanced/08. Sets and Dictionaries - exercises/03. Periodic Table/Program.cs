using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            var chemicalCompounds = new HashSet<string>();

            for (int i = 0; i < numOfLines; i++)
            {
                var inputLines = Console.ReadLine()
                    .Split()
                    .ToArray();
                for (int j = 0; j < inputLines.Length; j++)
                {
                    chemicalCompounds.Add(inputLines[j]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalCompounds.OrderBy(x => x)));
        }
    }
}
