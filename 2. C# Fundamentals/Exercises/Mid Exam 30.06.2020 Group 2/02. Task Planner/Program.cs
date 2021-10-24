using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Task_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> dailyTasks = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split();

            while (!command.Contains("End"))
            {
                switch (command[0])
                {
                    case "Complete":
                        Complete(dailyTasks, int.Parse(command[1]));
                        break;
                    case "Change":
                        Change(dailyTasks, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "Drop":
                        Drop(dailyTasks, int.Parse(command[1]));
                        break;
                    case "Count":
                        switch (command[1])
                        {
                            case "Completed":
                                CountCompleted(dailyTasks);
                                break;
                            case "Incomplete":
                                CountIncomplete(dailyTasks);
                                break;
                            case "Dropped":
                                CountDropped(dailyTasks);
                                break;
                        }
                        break;
                }

                command = Console.ReadLine().Split();
            }

            foreach (var time in dailyTasks)
            {
                if (time> 0)
                {
                    Console.Write(time + " ");
                }
            }
        }

        static void Complete(List<int> list, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list[index] = 0;
            }
        }

        static void Change(List<int> list, int index, int time)
        {
            if (index >= 0 && index < list.Count)
            {
                list[index] = time;
            }
        }

        static void Drop(List<int> list, int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list[index] = -1;
            }
        }

        static void CountCompleted(List<int> list)
        {
            int counter = 0;
            foreach (var element in list)
            {
                if (element == 0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        static void CountIncomplete(List<int> list)
        {
            int counter = 0;
            foreach (var element in list)
            {
                if (element > 0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }

        static void CountDropped(List<int> list)
        {
            int counter = 0;
            foreach (var element in list)
            {
                if (element == -1)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
