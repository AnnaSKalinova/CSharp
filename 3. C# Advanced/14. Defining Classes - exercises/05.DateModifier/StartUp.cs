using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            DateTime secondDate = DateTime.Parse(Console.ReadLine());

            DateModifier dateModifier = new DateModifier(firstDate, secondDate);

            int diffDays = dateModifier.Difference(firstDate, secondDate);

            Console.WriteLine(diffDays);
        }
    }
}
