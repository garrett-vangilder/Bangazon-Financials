using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Models
{
    /**
     * Class: CustomerOrder
     * Purpose: Creates a DB model to store and manipulate DB CustomerOrder entities
     * Author: Garrett Vangilder
     */
    public class CustomerOrder
    {
        [Key]
        public int CustomerOrderId { get; set; }

        [Required]
        public DateTime DateCompleted { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public ICollection<LineItem> LineItems;


    }
}
