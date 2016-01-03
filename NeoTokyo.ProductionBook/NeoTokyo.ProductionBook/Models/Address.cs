using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Display(Name = "Address Name")]
        public String AddressName { get; set; }
        [Display(Name = "Address Line 1")]
        public String AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public String AddressLine2 { get; set; }
        public String Town { get; set; }
        public String County { get; set; }
        public Guid CountryID { get; set; }
        public String PostCode { get; set; }
        public Boolean Active { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<CustomerAddressLink> CustomerAddressLinks { get; set; } 
    }
}