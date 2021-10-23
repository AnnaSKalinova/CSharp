using System;

namespace _07.WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeFor1Meter = double.Parse(Console.ReadLine());

            double ivansTime = distance * timeFor1Meter;

            double slow = Math.Floor(distance / 15);
            ivansTime += slow * 12.5;

            if (ivansTime < worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {(ivansTime):F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(ivansTime - worldRecord):F2} seconds slower.");
            }
        }
    }
}
