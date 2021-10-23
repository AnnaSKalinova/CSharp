using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPpl = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            double totalPrice = 0.0;

            switch (typeOfGroup)
            {
                case "Students":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            totalPrice = countOfPpl * 8.45;
                            break;
                        case "Saturday":
                            totalPrice = countOfPpl * 9.80;
                            break;
                        case "Sunday":
                            totalPrice = countOfPpl * 10.46;
                            break;
                        default:
                            break;
                    }
                    if (countOfPpl >= 30)
                    {
                        totalPrice -= 0.15 * totalPrice;
                    }
                    break;
                case "Business":
                    if (countOfPpl >= 100)
                    {
                        countOfPpl -= 10;
                    }
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            totalPrice = countOfPpl * 10.90;
                            break;
                        case "Saturday":
                            totalPrice = countOfPpl * 15.60;
                            break;
                        case "Sunday":
                            totalPrice = countOfPpl * 16;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Regular":
                    switch (dayOfWeek)
                    {
                        case "Friday":
                            totalPrice = countOfPpl * 15;
                            break;
                        case "Saturday":
                            totalPrice = countOfPpl * 20;
                            break;
                        case "Sunday":
                            totalPrice = countOfPpl * 22.50;
                            break;
                        default:
                            break;
                    }
                    if (countOfPpl >= 10 && countOfPpl <= 20)
                    {
                        totalPrice -= 0.05 * totalPrice;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
