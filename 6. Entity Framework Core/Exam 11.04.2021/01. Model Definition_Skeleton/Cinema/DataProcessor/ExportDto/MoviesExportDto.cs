using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ExportDto
{
    public class MoviesExportDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string MovieName { get; set; }

        [Range(1, 10)]
        public double Rating { get; set; }

        public decimal TotalIncomes { get; set; }

        public MovieCustomerExportDto[] Customers { get; set; }
    }
}
