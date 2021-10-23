using System;

namespace _02.BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());
            double bonusPoints = 0;

            if (points <= 100)
            {
                bonusPoints = 5;
            }
            else if (points > 100 && points <= 1000)
            {
                bonusPoints = 20 * points / 100.0;
            }
            else if (points > 1000)
            {
                bonusPoints = 10 * points / 100.0;
            }
            if (points % 2 == 0)
            {
                bonusPoints += 1;
            }
            else if (points % 10 == 5)
            {
                bonusPoints += 2;
            }
            Console.WriteLine(bonusPoints);
            Console.WriteLine(bonusPoints + points);
        }
    }
}
