using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class CustomerAddressLink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("Address")]
        public Guid AddressID { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public Int32 AddressTypeInt { get; set; }
        public Boolean Active { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
    }
}