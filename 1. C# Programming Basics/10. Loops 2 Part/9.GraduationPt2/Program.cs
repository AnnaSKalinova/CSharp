using System;

namespace _9.GraduationPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            double totalGrades = 0;
            int currentGrade = 1;
            double averageGrade = 0;
            int countRetakes = 0;

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
                    countRetakes++;
                    if (countRetakes <= 1)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (countRetakes <= 1)
            {
                averageGrade = totalGrades / 12;
                if (averageGrade >= 4)
                {
                    Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
                }
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {currentGrade} grade");
            }
        }
    }
}
