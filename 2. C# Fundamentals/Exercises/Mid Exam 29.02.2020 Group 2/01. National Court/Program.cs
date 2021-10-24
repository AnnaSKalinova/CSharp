using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPplFirst = int.Parse(Console.ReadLine());
            int countOfPplSecond = int.Parse(Console.ReadLine());
            int countOfPplThird = int.Parse(Console.ReadLine());
            int totalPplCountWaiting = int.Parse(Console.ReadLine());

            int totalPplCountAnswered = countOfPplFirst + countOfPplSecond + countOfPplThird;
            int breaks = 0;
            int timeNeeded = 1;
            totalPplCountWaiting -= totalPplCountAnswered;

            //if (totalPplCountWaiting >= totalPplCountAnswered)
            //{
            //    timeNeeded = (totalPplCountWaiting / totalPplCountAnswered);
            //}
            //if (totalPplCountWaiting % totalPplCountAnswered != 0)
            //{
            //    timeNeeded++;
            //}
            //if (timeNeeded >= 3)
            //{
            //    timeNeeded += timeNeeded / 3;
            //}

            //Console.WriteLine($"Time needed: {timeNeeded}h.");

            while (totalPplCountWaiting > 0)
            {
                if (timeNeeded % 3 == 0)
                {
                    breaks++;
                }
                totalPplCountWaiting -= totalPplCountAnswered;
                timeNeeded++;
            }

            Console.WriteLine($"Time needed: {timeNeeded + breaks}h.");
        }
    }
}
