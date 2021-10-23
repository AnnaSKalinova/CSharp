using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class Commit
    {
        public int Id { get; set; }

        [MinLength(5)]
        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public int CreatorId { get; set; }
        public User Creator { get; set; }

        [Required]
        public int RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
