using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class CustomerDefaultInvoiceAddress
    {
        [Key, ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        [ForeignKey("Address")]
        public Guid AddressID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Address Address { get; set; }
    }
}