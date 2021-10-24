using System;
using System.Linq;
using System.Text;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var destinations = Console.ReadLine();
            var command = Console.ReadLine().Split(':').ToArray();

            StringBuilder sb = new StringBuilder();

            while (!command.Contains("Travel"))
            {
                var action = command[0];

                switch (action)
                {
                    case "Add Stop":
                        sb.Append(destinations);
                        var index = int.Parse(command[1]);
                        var stringToInsert = command[2];

                        if (index >= 0 && index < destinations.Length)
                        {
                            sb.Insert(index, stringToInsert);
                        }
                        destinations = sb.ToString();

                        Console.WriteLine(destinations);
                        break;
                    case "Remove Stop":
                        sb.Append(destinations);
                        var startIndex = int.Parse(command[1]);
                        var endIndex = int.Parse(command[2]);

                        if (startIndex >= 0 && startIndex < destinations.Length && endIndex >= 0 && endIndex < destinations.Length)
                        {
                            sb.Remove(startIndex, endIndex - startIndex + 1);
                        }
                        destinations = sb.ToString();

                        Console.WriteLine(destinations);
                        break;
                    case "Switch":
                        sb.Append(destinations);
                        var oldString = command[1];
                        var newString = command[2];

                        sb.Replace(oldString, newString);

                        destinations = sb.ToString();
                        sb.Clear();
                        Console.WriteLine(destinations);
                        break;
                }

                sb.Clear();
                command = Console.ReadLine().Split(':').ToArray();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {destinations}");
        }
    }
}
