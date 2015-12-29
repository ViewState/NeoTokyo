using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Display(Name = "Name")]
        public String CountryName { get; set; }
        [Display(Name = "Code")]
        public String CountryCode { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } 
    }
}