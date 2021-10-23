using System;
using System.Linq;
using System.Reflection.Metadata;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path= Console.ReadLine().Split('\\', '.').ToArray();

            string fileName = path[path.Length - 2];
            string extension = path[path.Length - 1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
