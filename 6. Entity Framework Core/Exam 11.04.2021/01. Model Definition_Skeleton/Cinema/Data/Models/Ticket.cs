using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data
{
    public class Ticket
    {
        public int Id { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey(nameof(Projection))]
        public int ProjectionId { get; set; }
        public Projection Projection { get; set; }
    }
}
