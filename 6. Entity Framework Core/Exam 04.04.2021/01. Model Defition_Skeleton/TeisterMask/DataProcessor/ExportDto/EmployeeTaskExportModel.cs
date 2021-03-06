using System;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class EmployeeTaskExportModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string TaskName { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        [Required]
        public string LabelType { get; set; }

        [Required]
        public string ExecutionType { get; set; }

    }
}
