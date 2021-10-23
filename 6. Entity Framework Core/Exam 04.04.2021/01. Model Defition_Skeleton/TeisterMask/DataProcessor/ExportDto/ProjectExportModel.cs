using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Data.Models;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectExportModel
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        public ProjectTaskExportModel[] Tasks { get; set; }
    }
}
