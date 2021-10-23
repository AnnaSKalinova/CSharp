using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class Repository
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(10)]
        [Required]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsPublic { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Commit> Commits = new HashSet<Commit>();
    }
}