using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class Designer
    {
        [Key, ForeignKey("Staff")]
        public Guid StaffID { get; set; }
        public Boolean Active { get; set; }

        public virtual Staff Staff { get; set; }
    }
}