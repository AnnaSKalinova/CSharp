using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class EmployeesImportModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(GlobalConstants.UsernameValidation)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PhoneValidation)]
        public string Phone { get; set; }

        public List<int> Tasks { get; set; }
    }
}
