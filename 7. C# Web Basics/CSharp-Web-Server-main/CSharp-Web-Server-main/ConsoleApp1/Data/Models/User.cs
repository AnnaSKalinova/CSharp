using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Git.Data.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [MinLength(5)]
        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [MinLength(6)]
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        public ICollection<Repository> Repositories = new HashSet<Repository>();

        public ICollection<Commit> Commits = new HashSet<Commit>();
    }
}