using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class Repository
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MinLength(3)]
        [MaxLength(10)]
        [Required]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<Commit> Commits = new HashSet<Commit>();
    }
}