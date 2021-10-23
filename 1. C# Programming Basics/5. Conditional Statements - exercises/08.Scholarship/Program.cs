using System;

namespace _08.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double uspeh = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = 0.0;
            double scoreScholarship = 0.0;
            if ((income < minSalary) && (uspeh >= 4.50))
            {
                socialScholarship = 0.35 * minSalary;
            }
            if (uspeh >= 5.50)
            {
                scoreScholarship = uspeh * 25;
            }

            if (socialScholarship == 0 && scoreScholarship == 0)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (socialScholarship != 0 && scoreScholarship != 0)
            {
                if (socialScholarship > scoreScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scoreScholarship)} BGN");
                }
            }
            else if (socialScholarship != 0 && scoreScholarship == 0)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
            else if (socialScholarship == 0 && scoreScholarship != 0)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scoreScholarship)} BGN");
            }
        }
    }
}
