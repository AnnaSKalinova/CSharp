using System;

namespace _08.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double studioPrice = 0.0;
            double apartmentPrice = 0.0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50 * nightsCount;
                    apartmentPrice = 65 * nightsCount;
                    if (nightsCount > 7 && nightsCount < 14)
                    {
                        studioPrice -= 0.05 * studioPrice;
                    }
                    else if (nightsCount > 14)
                    {
                        studioPrice -= 0.30 * studioPrice;
                        apartmentPrice -= 0.10 * apartmentPrice;
                    }
                    break;
                case "June":
                case "September":
                    studioPrice = 75.20 * nightsCount;
                    apartmentPrice = 68.70 * nightsCount;
                    if (nightsCount > 14)
                    {
                        studioPrice -= 0.20 * studioPrice;
                        apartmentPrice -= 0.10 * apartmentPrice;
                    }
                    break;
                case "July":
                case "August":
                    studioPrice = 76 * nightsCount;
                    apartmentPrice = 77 * nightsCount;
                    if (nightsCount > 14)
                    {
                        apartmentPrice -= 0.10 * apartmentPrice;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Apartment: {apartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice:F2} lv.");
        }
    }
}
