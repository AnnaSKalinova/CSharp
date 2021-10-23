using System;

namespace _10.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekendsHomeTown = double.Parse(Console.ReadLine());

            double volleyballGames = ((48 - weekendsHomeTown) * 3 / 4) + (holidays * 2 / 3) + weekendsHomeTown;

            switch (yearType)
            {
                case "leap":
                    volleyballGames += 0.15 * volleyballGames;
                    break;
                default:
                    break;
            }
            Console.WriteLine(Math.Floor(volleyballGames));
        }
    }
}
