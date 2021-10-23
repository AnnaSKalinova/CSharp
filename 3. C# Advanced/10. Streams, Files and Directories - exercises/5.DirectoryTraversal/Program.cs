using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileInfo = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo("../../../");
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                if (!fileInfo.ContainsKey(file.Extension))
                {
                    fileInfo.Add(file.Extension, new Dictionary<string, double>());
                }

                fileInfo[file.Extension].Add(file.Name, file.Length / 1000.00);
            }

            using (StreamWriter writer = new StreamWriter(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DirectoryTraversal.txt"))
            {
                foreach (var item in fileInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
                {
                    writer.WriteLine(item.Key);

                    foreach (var element in item.Value.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"--{element.Key} - {element.Value}kb");
                    }
                }
            }
        }
    }
}
