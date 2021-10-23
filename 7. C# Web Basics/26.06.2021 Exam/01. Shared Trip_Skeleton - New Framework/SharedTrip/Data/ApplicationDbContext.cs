namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Models;
    using System.Collections.Generic;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; init; }

        public DbSet<User> Users { get; init; }

        public DbSet<UserTrip> UserTrips { get; init; }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.TripId,
                    e.UserId
                });
            });
        }
    }
}
