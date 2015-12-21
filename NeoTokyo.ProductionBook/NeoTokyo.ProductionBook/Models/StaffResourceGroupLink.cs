using System;

namespace NeoTokyo.ProductionBook.Models
{
    public class StaffResourceGroupLink
    {
        public Guid StaffID { get; set; }
        public Guid ResourceGroupID { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual ResourceGroup ResourceGroup { get; set; }
    }
}