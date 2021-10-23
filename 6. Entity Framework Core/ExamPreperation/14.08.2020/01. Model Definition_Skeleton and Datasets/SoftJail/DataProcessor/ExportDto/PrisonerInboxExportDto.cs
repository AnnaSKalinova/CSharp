using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class PrisonerInboxExportDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public PrisonerInboxMessageExportDto[] EncryptedMessages { get; set; }
    }
}
