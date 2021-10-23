using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] currentCourse = Console.ReadLine().Split(" : ").ToArray();

            var courses = new Dictionary<string, List<string>>();

            while (!currentCourse.Contains("end"))
            {
                string courseName = currentCourse[0];
                string studentName = currentCourse[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }
                courses[courseName].Add(studentName);

                currentCourse = Console.ReadLine().Split(" : ").ToArray();
            }

            foreach (var course in courses
                .OrderByDescending(x => x.Value.Count())
                .ToArray())
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                
                foreach (var student in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
