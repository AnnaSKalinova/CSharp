using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ExportDto
{
    public class PrisonerExportDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        public int? CellNumber { get; set; }

        public IEnumerable<PrisonerOfficerExportDto> Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }
}
