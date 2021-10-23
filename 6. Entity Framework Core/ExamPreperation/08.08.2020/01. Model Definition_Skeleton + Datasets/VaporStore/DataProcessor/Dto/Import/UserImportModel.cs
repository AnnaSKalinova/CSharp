using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class UserImportModel
    {
        [Required]
        [RegularExpression(GlobalConstants.FullNameValidation)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UsernameMaxLength)]
        [MinLength(GlobalConstants.UsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3,103)]
        public int Age { get; set; }

        public IEnumerable<UserCardImportModel> Cards { get; set; }
    }
}
