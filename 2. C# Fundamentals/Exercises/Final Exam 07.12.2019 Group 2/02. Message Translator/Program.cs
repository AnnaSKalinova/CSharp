using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfMessages = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfMessages; i++)
            {
                var list = new List<int>();
                var text = Console.ReadLine();
                var pattern = @"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(text);

                if (match.Success)
                {
                    var command = match.Groups[1].Value;
                    var message = match.Groups[2].Value;

                    for (int j  = 0; j < message.Length; j++)
                    {
                        list.Add((int)message[j]);
                    }

                    Console.WriteLine($"{command}: {string.Join(" ", list)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
