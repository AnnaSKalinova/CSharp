using System;
using System.Numerics;

namespace _01_SoftuniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiencyPerHour = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiencyPerHour = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiencyPerHour = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int totalEmployeeEfficiency = firstEmployeeEfficiencyPerHour + secondEmployeeEfficiencyPerHour + thirdEmployeeEfficiencyPerHour;
            int hourCounter = 0;

            while (studentsCount > 0)
            {
                hourCounter++;
                if (hourCounter % 4 == 0)
                {
                    continue;
                }
                studentsCount -= totalEmployeeEfficiency;
            }

            Console.WriteLine($"Time needed: {hourCounter}h.");
        }
    }
}
