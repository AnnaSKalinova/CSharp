using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; init; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips = new HashSet<UserTrip>();
    }
}
