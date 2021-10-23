using System;

namespace _08.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double totalGrades = 0;
            int currentGrade = 1;
            double averageGrade = 0;
            
            while (currentGrade <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    totalGrades += grade;
                    currentGrade++;
                }
                else
                {
                    continue;
                }
            }
            averageGrade = totalGrades / 12;
            if (averageGrade >= 4)
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}
