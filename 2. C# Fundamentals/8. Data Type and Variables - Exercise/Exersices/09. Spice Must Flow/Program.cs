using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int totalAmountOfSpace = 0;
            int days = 0;

            if (yield < 100)
            {
                Console.WriteLine(days);
                Console.WriteLine(totalAmountOfSpace);
            }
            else
            {
                while (yield >= 100)
                {
                    days++;
                    totalAmountOfSpace += yield - 26;
                    yield -= 10;
                }
                totalAmountOfSpace -= 26;
                Console.WriteLine(days);
                Console.WriteLine(totalAmountOfSpace);
            }
        }
    }
}
