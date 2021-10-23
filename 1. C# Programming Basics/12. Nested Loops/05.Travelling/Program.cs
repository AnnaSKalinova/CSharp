using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while (input != "End")
            {
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                double budget = double.Parse(Console.ReadLine());
                double moneySaved = 0.0;

                while (moneySaved < budget)
                {
                    input = Console.ReadLine();
                    moneySaved += double.Parse(input);
                }
                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}
