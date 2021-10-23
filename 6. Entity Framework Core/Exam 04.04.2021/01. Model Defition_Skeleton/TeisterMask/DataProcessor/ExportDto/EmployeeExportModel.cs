using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    public partial class EmployeeExportModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(GlobalConstants.UsernameValidation)]
        public string Username { get; set; }


        public EmployeeTaskExportModel[] Tasks { get; set; }

    }
}
