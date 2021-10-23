using System;

namespace _09.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minExam = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minArrival = int.Parse(Console.ReadLine());

            int timeExam = hourExam * 60 + minExam;
            int timeArrival = hourArrival * 60 + minArrival;
            int minDifference = Math.Abs(timeExam - timeArrival);
            int hourDifference = 0;
            if (minDifference >= 60)
            {
                hourDifference = minDifference / 60;
                minDifference %= 60;
            }

            if (timeExam - timeArrival >= 0 && timeExam - timeArrival <= 30)
            {
                Console.WriteLine("On time");
                if (minDifference != 0)
                {
                    Console.WriteLine($"{minDifference} minutes before the start");
                }
            }
            else if (timeExam - timeArrival > 30)
            {
                Console.WriteLine("Early");
                if (timeExam - timeArrival < 60)
                {
                    Console.WriteLine($"{minDifference} minutes before the start");
                }
                else
                {
                    if (minDifference < 10)
                    {
                        Console.WriteLine($"{hourDifference}:0{minDifference} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hourDifference}:{minDifference} hours before the start");
                    }
                }
            }
            else
            {
                Console.WriteLine("Late");
                if (timeArrival - timeExam < 60)
                {
                    Console.WriteLine($"{minDifference} minutes after the start");
                }
                else
                {
                    if (minDifference < 10)
                    {
                        Console.WriteLine($"{hourDifference}:0{minDifference} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hourDifference}:{minDifference} hours after the start");
                    }
                }
            }
        }
    }
}
