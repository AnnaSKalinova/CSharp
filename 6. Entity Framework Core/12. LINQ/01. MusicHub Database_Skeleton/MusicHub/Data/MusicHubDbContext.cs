namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongPerformers { get; set; }
        public DbSet<Writer> Writers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.SongId,
                    e.PerformerId
                });

                entity.HasOne(e => e.Song)
                    .WithMany(s => s.SongPerformers)
                    .HasForeignKey(e => e.SongId);

                entity.HasOne(e => e.Performer)
                    .WithMany(p => p.PerformerSongs)
                    .HasForeignKey(e => e.PerformerId);
            });

            builder.Entity<Song>(entity => 
            {
                entity.HasOne(e => e.Writer)
                    .WithMany(e => e.Songs)
                    .HasForeignKey(e => e.WriterId);

                entity.HasOne(e => e.Album)
                    .WithMany(a => a.Songs)
                    .HasForeignKey(e => e.AlbumId);
            });

            builder.Entity<Album>(entity => 
            {
                entity.HasOne(e => e.Producer)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(e => e.ProducerId);
            });
        }
    }
}
