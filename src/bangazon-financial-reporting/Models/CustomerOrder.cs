using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Models
{
    public class CustomerOrder
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime DateCompleted { get; set; }

        [Required]
        public int CustomerId { get; set; }

    }
}
