using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Export
{
    public partial class GamesByGenresExportModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Genre { get; set; }

        public GamesByGenresExportModelGames[] Games { get; set; }

        [Required]
        public int TotalPlayers { get; set; }

    }
}
