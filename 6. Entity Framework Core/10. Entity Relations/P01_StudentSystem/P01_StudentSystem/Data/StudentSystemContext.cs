using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
           {
               entity.HasKey(e => new
               {
                   e.CourseId,
                   e.StudentId
               });

               entity.HasOne(e => e.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(e => e.StudentId);

               entity.HasOne(e => e.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(e => e.CourseId);
           });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasOne(e => e.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasOne(e => e.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(e => e.CourseId);
            });
        }
    }
}
