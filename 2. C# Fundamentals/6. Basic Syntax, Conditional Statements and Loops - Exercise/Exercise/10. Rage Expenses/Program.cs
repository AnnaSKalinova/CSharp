using System;

namespace _9._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGameCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double rageExpenses = 0.0;

            if (lostGameCount >= 2)
            {
                rageExpenses += headsetPrice * (lostGameCount / 2);
            }
            if (lostGameCount >= 3)
            {
                rageExpenses += mousePrice * (lostGameCount / 3);
            }
            if (lostGameCount >= 6)
            {
                rageExpenses += keyboardPrice * (lostGameCount / 6);
            }
            if (lostGameCount >= 12)
            {
                rageExpenses += displayPrice * (lostGameCount / 12);
            }
            Console.WriteLine($"Rage expenses: {rageExpenses:F2} lv.");
        }
    }
}
