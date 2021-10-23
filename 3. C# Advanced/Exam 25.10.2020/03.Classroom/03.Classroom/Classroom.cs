using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.Students = new List<Student>();
        }
        public int Capacity { get; set; }
        public List<Student> Students { get; set; }
        public int Count => this.Students.Count;

        public string RegisterStudent(Student student)
        {
            StringBuilder sb = new StringBuilder();

            if (this.Students.Count <= this.Capacity - 1)
            {
                this.Students.Add(student);
                sb.AppendLine($"Added student {student.FirstName} {student.LastName}");
            }
            else
            {
                sb.AppendLine("No seats in the classroom");
            }

            return sb.ToString().TrimEnd();
        }

        public string DismissStudent(string firstName, string lastName)
        {
            StringBuilder sb = new StringBuilder();

            if (this.Students.Any(s => (s.FirstName == firstName && s.LastName == lastName)))
            {
                Student studentToRemove = this.Students.Where(s => (s.FirstName == firstName && s.LastName == lastName)).First();

               sb.AppendLine($"Dismissed student {studentToRemove.FirstName} {studentToRemove.LastName}");

                this.Students.Remove(studentToRemove);
            }
            else
            {
                sb.AppendLine("Student not found");
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            if (this.Students.Any(s => s.Subject == subject))
            {
                var studentsWithGivenSubject = this.Students.Where(s => s.Subject == subject);

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in studentsWithGivenSubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }
            else
            {
                sb.AppendLine("No students enrolled for the subject");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
           int studentsCount = this.Students.Count();

            return studentsCount;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student studentToFind = this.Students.Where(s => s.FirstName == firstName && s.LastName == lastName).FirstOrDefault();
            
            return studentToFind;
        }
    }
}
