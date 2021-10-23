using System;

namespace _05.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int transferCount = int.Parse(Console.ReadLine());

            double total = 0.0;
            int count = 1;

            while (count <= transferCount)
            {
                double transfer = double.Parse(Console.ReadLine());
                if (transfer <= 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {transfer:f2}");
                total += transfer;
                count++;
            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
