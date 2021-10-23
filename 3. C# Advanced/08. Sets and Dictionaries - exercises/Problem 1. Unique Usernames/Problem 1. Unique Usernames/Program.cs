using System;
using System.Collections.Generic;

namespace Problem_1._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < numOfLines; i++)
            {
                string username = Console.ReadLine();
                names.Add(username);
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
