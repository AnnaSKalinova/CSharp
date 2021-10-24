using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "course start")
            {
                string[] tokens = command.Split(':');
                switch (tokens[0])
                {
                    case "Add":
                        Add(schedule, tokens[1]);
                        break;
                    case "Insert":
                        Insert(schedule, tokens[1], int.Parse(tokens[2]));
                        break;
                    case "Remove":
                        Remove(schedule, tokens[1]);
                        break;
                    case "Swap":
                        Swap(schedule, tokens[1], tokens[2]);
                        break;
                    case "Exercise":
                        Exercise(schedule, tokens[1]);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }

        static void Add(List<string> list, string lessonTitle)
        {
            bool isLessonTitleIn = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lessonTitle)
                {
                    isLessonTitleIn = true;
                }
            }

            if (!isLessonTitleIn)
            {
                list.Add(lessonTitle);
            }
        }

        static void Insert(List<string> list, string lessonTitle, int index)
        {
            bool isLessonTitleIn = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lessonTitle)
                {
                    isLessonTitleIn = true;
                }
            }

            if (!isLessonTitleIn)
            {
                list.Insert(index, lessonTitle);
            }
        }

        static void Remove(List<string> list, string lessonTitle)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lessonTitle)
                {
                    if (i < list.Count - 1 && list[i + 1] == lessonTitle + "-Exercise")
                    {
                        list.RemoveAt(i + 1);
                    }
                    list.RemoveAt(i);
                }
            }
        }

        static void Swap(List<string> list, string lessonTitleOne, string lessonTitleTwo)
        {
            int indexOne = 0;
            int indexTwo = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lessonTitleOne)
                {
                    indexOne = i;
                }
                if (list[i] == lessonTitleTwo)
                {
                    indexTwo = i;
                }
            }
            list.RemoveAt(indexOne);
            list.Insert(indexOne, lessonTitleTwo);
            list.RemoveAt(indexTwo);
            list.Insert(indexTwo, lessonTitleOne);

            if (indexOne < list.Count - 1 && list[indexOne + 1] == lessonTitleOne + "-Exercise")
            {
                list.RemoveAt(indexOne + 1);
                list.Insert(indexTwo + 1, lessonTitleOne + "-Exercise");
            }
            if (indexTwo < list.Count - 1 && list[indexTwo + 1] == lessonTitleTwo + "-Exercise")
            {
                list.RemoveAt(indexTwo + 1);
                list.Insert(indexOne + 1, lessonTitleTwo + "-Exercise");
            }
        }
        static void Exercise(List<string> list, string lessonTitle)
        {
            bool isLessonTitleIn = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lessonTitle)
                {
                    isLessonTitleIn = true;
                    list.Insert(i + 1, lessonTitle + "-Exercise");
                }
            }
            if (!isLessonTitleIn)
            {
                list.Add(lessonTitle);
                list.Add(lessonTitle + "-Exercise");
            }
        }
    }
}
