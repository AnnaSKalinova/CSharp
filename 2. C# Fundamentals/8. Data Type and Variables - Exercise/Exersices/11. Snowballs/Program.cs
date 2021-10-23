using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());

            int highestSnowballSnow = 0;
            int highestSnowballTime = 0;
            BigInteger highestSnowballValue = 0;
            int highestSnowballQuality = 0;

            for (int i = 0; i < countOfLines; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = 1;

                for (int j = 0; j < snowballQuality; j++)
                {
                    snowballValue *= snowballSnow / snowballTime;
                }

                if (snowballValue > highestSnowballValue)
                {
                    highestSnowballValue = snowballValue;
                    highestSnowballSnow = snowballSnow;
                    highestSnowballTime = snowballTime;
                    highestSnowballQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestSnowballValue} ({highestSnowballQuality})");
        }
    }
}
