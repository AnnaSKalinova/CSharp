using System;

namespace _04.MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            if (input == "mm")
            {
                if (output == "m")
                {
                    number /= 1000;
                }
                if (output == "cm")
                {
                    number /= 10;
                }
            }
            if (input == "cm")
            {
                if (output == "m")
                {
                    number /= 100;
                }
                if (output == "mm")
                {
                    number *= 10;
                }
            }
            if (input == "m")
            {
                if (output == "cm")
                {
                    number *= 100;
                }
                if (output == "mm")
                {
                    number *= 1000;
                }
            }
            Console.WriteLine($"{number:F3}");
        }
    }
}
