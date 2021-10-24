using System;
using System.Numerics;

namespace _01._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal biscuitsPerDayPerWorker = decimal.Parse(Console.ReadLine());
            decimal workersCount = decimal.Parse(Console.ReadLine());
            decimal competingBiscuitsCountFor30Days = decimal.Parse(Console.ReadLine());

            decimal biscuitsPerDaysNormal = workersCount * biscuitsPerDayPerWorker;
            decimal biscuitsPerDayRedused = Math.Floor(workersCount * biscuitsPerDayPerWorker * 0.75M);
            decimal total =  20 * biscuitsPerDaysNormal + 10 * biscuitsPerDayRedused;

            Console.WriteLine($"You have produced {total} biscuits for the past month.");

            decimal percentageDifference = 0.0M;

            if (total > competingBiscuitsCountFor30Days)
            {
                decimal difference = total - competingBiscuitsCountFor30Days;
                percentageDifference = difference / competingBiscuitsCountFor30Days * 100;
                Console.WriteLine($"You produce {percentageDifference:F2} percent more biscuits.");
            }
            else
            {
                decimal difference = competingBiscuitsCountFor30Days - total;
                percentageDifference = difference / competingBiscuitsCountFor30Days * 100;
                Console.WriteLine($"You produce {percentageDifference:F2} percent less biscuits.");
            }
        }
    }
}
