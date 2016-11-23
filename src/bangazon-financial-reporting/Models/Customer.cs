using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string State { get; set; }

        //Foreign Key Dependencies
        public ICollection<CustomerOrder> Orders;

    }
}
