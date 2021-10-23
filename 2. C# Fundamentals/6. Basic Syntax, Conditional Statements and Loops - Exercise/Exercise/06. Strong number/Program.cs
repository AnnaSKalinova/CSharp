using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int sum = 0;
            int factorial = 1;

            for (int i = 0; i < number.Length; i++)
            {
                int currentNum = int.Parse(number[i].ToString());
                for (int j = 1; j <= currentNum; j++)
                {
                    factorial *= j;
                }
                sum += factorial;
                factorial = 1;
            }

            if (sum == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
