using System;
using System.Collections.Generic;

namespace _07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimeter = Console.ReadLine();

            List<string> output = new List<string>();

            output.Add(firstName);
            output.Add(delimeter);
            output.Add(secondName);

            Console.WriteLine(string.Join("", output));
        }
    }
}
