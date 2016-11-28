using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Models
{
    /**
     * Class: Product
     * Purpose: Creates a DB model to store and manipulate DB Product entities
     * Author: Garrett Vangilder
     */
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Revenue { get; set; }

        public ICollection<LineItem> LineItems;


    }
}
