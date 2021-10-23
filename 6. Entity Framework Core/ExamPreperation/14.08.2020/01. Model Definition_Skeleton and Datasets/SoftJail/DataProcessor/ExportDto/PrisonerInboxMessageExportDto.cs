using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class PrisonerInboxMessageExportDto
    {
        [Required]
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
