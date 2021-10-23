using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Projection")]
    public class ProjectionImportDto
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string DateTime { get; set; }
    }
}
