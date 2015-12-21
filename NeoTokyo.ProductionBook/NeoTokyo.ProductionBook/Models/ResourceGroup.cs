using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class ResourceGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Display(Name = "Resource Group")]
        public String Name { get; set; }

        public virtual ICollection<StaffResourceGroupLink> StaffResourceGroupLinks { get; set; }
    }
}