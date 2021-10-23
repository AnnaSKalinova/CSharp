using System;

namespace _01.SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstSec = int.Parse(Console.ReadLine());
            int secondSec = int.Parse(Console.ReadLine());
            int thirdSec = int.Parse(Console.ReadLine());

            int totalTime = firstSec + secondSec + thirdSec;
            int minutes = 0;

            if (totalTime >= 60)
            {
                minutes = totalTime / 60;
                totalTime %= 60;
            }
            if (totalTime < 10)
            {
                Console.WriteLine(minutes + ":0" + totalTime);
            }
            else
            {
                Console.WriteLine(minutes + ":" + totalTime);
            }
        }
    }
}
