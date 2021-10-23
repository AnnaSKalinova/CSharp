using System;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var threads = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var taskToKill = int.Parse(Console.ReadLine());

            var killedThread = 0;
            var killedTask = 0;

            while (true)
            {
                if (tasks[tasks.Count - 1] == taskToKill)
                {
                    killedThread = threads[0];
                    killedTask = tasks[tasks.Count - 1];
                    break;
                }
                if (threads[0] >= tasks[tasks.Count - 1])
                {
                    threads.RemoveAt(0);
                    tasks.RemoveAt(tasks.Count - 1);
                }
                else if (threads[0] < tasks[tasks.Count - 1])
                {
                    threads.RemoveAt(0);
                }
            }

            Console.WriteLine($"Thread with value {killedThread} killed task {killedTask}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
