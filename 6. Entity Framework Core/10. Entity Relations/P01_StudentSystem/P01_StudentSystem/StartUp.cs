using System;

namespace P01_StudentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new P01_StudentSystem.Data.StudentSystemContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
