using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Models
{
    /**
     * Class: LineItem
     * Purpose: Creates a DB model to store and manipulate DB LineItem entities
     * Author: Garrett Vangilder
     */
    public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerOderId { get; set; }
    }
}
