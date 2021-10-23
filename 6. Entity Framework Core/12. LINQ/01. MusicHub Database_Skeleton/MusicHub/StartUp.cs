namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using System.Linq;
    using Initializer;
    using System.Globalization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            // Problem 2
            //var albums = ExportAlbumsInfo(context, 9);
            //Console.WriteLine(albums);

            // Problem 3
            var songs = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(songs);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context
                    .Albums
                    .ToList()
                    .Where(a => a.ProducerId == producerId)
                    .Select(a => new
                    {
                        Name = a.Name,
                        ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                        ProducerName = a.Producer.Name,
                        AlbumSongs = a.Songs.Select(s => new
                        {
                            Name = s.Name,
                            Price = s.Price,
                            SongWriter = s.Writer.Name
                        })
                            .OrderByDescending(s => s.Name)
                            .ThenBy(s => s.SongWriter)
                            .ToList(),
                        AlbumPrice = a.Price
                    })
                    .OrderByDescending(a => a.AlbumPrice)
                    .ToList();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");
                var counter = 1;

                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");
                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context
                .Songs
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    Name = s.Name,
                    Performer = s.SongPerformers
                           .Select
                           (p => p.Performer.FirstName + " " +    p.Performer.LastName).FirstOrDefault(),
                    Writer = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList();

            var counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
