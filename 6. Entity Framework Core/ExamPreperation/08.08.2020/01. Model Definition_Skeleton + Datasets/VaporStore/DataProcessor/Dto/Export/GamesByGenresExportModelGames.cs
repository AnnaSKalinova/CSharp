using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Export
{
    public partial class GamesByGenresExportModelGames
    {
        public class Game
        {
            [Required]
            public int Id { get; set; }

            [Required]
            public string Title { get; set; }

            [Required]
            public Developer Developer { get; set; }

            [Required]
            public Tag Tags { get; set; }

            [Required]
            public int Players { get; set; }
        }

    }
}
