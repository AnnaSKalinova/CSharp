using System;
using System.IO;
using System.Linq;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                int counter = 0;
                while (true)
                {
                    string line = reader.ReadLine();
                    char[] symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };
                    if (line == null)
                    {
                        break;
                    }
                    else
                    {
                        if (counter % 2 == 0)
                        {
                            line = line.Replace('-', '@');
                            line = line.Replace('.', '@');
                            line = line.Replace(',', '@');
                            line = line.Replace('!', '@');
                            line = line.Replace('?', '@');

                            line = String.Join(" ", line.Split(" ").Reverse().ToArray());
                            Console.WriteLine(line);
                        }
                    }
                    counter++;
                }
            }
        }
    }
}
