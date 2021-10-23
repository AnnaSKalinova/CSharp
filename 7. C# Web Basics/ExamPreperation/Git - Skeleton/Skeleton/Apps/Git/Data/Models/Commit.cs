using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        public int Id { get; set; }

        [MinLength(5)]
        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public int RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}