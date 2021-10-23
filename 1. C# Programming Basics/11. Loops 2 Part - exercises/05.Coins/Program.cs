using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputAmount = double.Parse(Console.ReadLine());

            double st0 = 2;
            double st1 = 1;
            double st2 = 0.50;
            double st3 = 0.20;
            double st4 = 0.10;
            double st5 = 0.05;
            double st6 = 0.02;
            double st7 = 0.01;

            int counter = 0;

            while (Math.Round(inputAmount, 2) >= st0)
            {
                inputAmount -= st0;
                counter++;
            }
            while (Math.Round(inputAmount, 2) >= st1)
            {
                inputAmount -= st1;
                counter++;
            }
            while (Math.Round(inputAmount, 2) >= st2)
            {
                inputAmount -= st2;
                counter++;
            }
            while (Math.Round(inputAmount, 2) >= st3)
            {
                inputAmount -= st3;
                counter++;
            }
            while (Math.Round(inputAmount, 2) >= st4)
            {
                inputAmount -= st4;
                counter++;
            }
            while (Math.Round(inputAmount, 2) >= st5)
            {
                inputAmount -= st5;
                counter++;
            }
            while (Math.Round(inputAmount, 2) >= st6)
            {
                inputAmount -= st6;
                counter++;
            }
            while (Math.Round(inputAmount, 2) >= st7)
            {
                inputAmount -= st7;
                counter++;
            }

            Console.WriteLine(counter);
        }
    }
}
