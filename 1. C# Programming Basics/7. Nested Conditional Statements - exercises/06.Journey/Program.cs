using System;

namespace _06.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string holidayType = "";
            double expences = 0.0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        expences = 0.30 * budget;
                        holidayType = "Camp";
                        break;
                    case "winter":
                        expences = 0.70 * budget;
                        holidayType = "Hotel";
                        break;
                    default:
                        break;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        expences = 0.40 * budget;
                        holidayType = "Camp";
                        break;
                    case "winter":
                        expences = 0.80 * budget;
                        holidayType = "Hotel";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                destination = "Europe";
                expences = 0.90 * budget;
                holidayType = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{holidayType} - {expences:F2}");
        }
    }
}
