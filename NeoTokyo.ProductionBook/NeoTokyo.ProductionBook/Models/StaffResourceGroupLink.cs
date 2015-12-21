using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class StaffResourceGroupLink
    {
        [Key]
        [ForeignKey("Staff")]
        public Guid StaffID { get; set; }
        public Guid ResourceGroupID { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual ResourceGroup ResourceGroup { get; set; }
    }
}