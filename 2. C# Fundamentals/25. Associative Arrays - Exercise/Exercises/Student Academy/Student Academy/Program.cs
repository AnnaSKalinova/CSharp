using System;
using System.Collections.Generic;
using System.Linq;

namespace Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfRows = int.Parse(Console.ReadLine());

            var academi = new Dictionary<string, List<double>>();

            for (int i = 0; i < numOfRows; i++)
            {
                string studentsName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!academi.ContainsKey(studentsName))
                {
                    academi.Add(studentsName, new List<double>());
                }
                academi[studentsName].Add(grade);
            }

            foreach (var student in academi
                .OrderByDescending(x => x.Value.Average())
                .ToArray())
            {
                if (student.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
                }
            }
        }
    }
}
