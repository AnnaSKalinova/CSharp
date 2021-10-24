using System;

namespace _04._Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int returnTimeHours = 0;
            int returnTimeMinutes = 0;

            returnTimeHours = hours;
            returnTimeMinutes = minutes + 30;

            if (returnTimeMinutes > 60)
            {
                returnTimeHours += returnTimeMinutes / 60;
                returnTimeMinutes %= 60;
            }

            if (returnTimeHours == 24)
            {
                returnTimeHours = 0;
            }

            if (returnTimeMinutes < 10)
            {
                Console.WriteLine($"{returnTimeHours}:0{returnTimeMinutes}");
            }
            else
            {
                Console.WriteLine($"{returnTimeHours}:{returnTimeMinutes}");
            }
        }
    }
}
