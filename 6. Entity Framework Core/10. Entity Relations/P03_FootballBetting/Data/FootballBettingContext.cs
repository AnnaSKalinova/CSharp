using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBetting;Integrated Security=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasOne(e => e.PrimaryKitColor)
                    .WithMany(pkc => pkc.PrimaryKitTeams)
                    .HasForeignKey(e => e.PrimaryKitColorId);

                entity.HasOne(e => e.SecondaryKitColor)
                    .WithMany(skc => skc.SecondaryKitTeams)
                    .HasForeignKey(e => e.SecondaryKitColorId);

                entity.HasOne(e => e.Town)
                    .WithMany(t => t.Teams)
                    .HasForeignKey(e => e.TownId);
            });
                   
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasOne(e => e.HomeTeam)
                    .WithMany(ht => ht.HomeGames)
                    .HasForeignKey(e => e.HomeTeamId);

                entity.HasOne(e => e.AwayTeam)
                    .WithMany(at => at.AwayGames)
                    .HasForeignKey(e => e.AwayTeamId);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasOne(e => e.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<Player>(entity => 
            {
                entity.HasOne(e => e.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(e => e.TeamId);

                entity.HasOne(e => e.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(e => e.PositionId);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.GameId,
                    e.PlayerId
                });

                entity.HasOne(e => e.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(e => e.GameId);

                entity.HasOne(e => e.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(e => e.PlayerId);
            });

            modelBuilder.Entity<Bet>(entity => 
            {
                entity.HasOne(e => e.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(e => e.GameId);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(e => e.UserId);
            });
        }
    }
}
