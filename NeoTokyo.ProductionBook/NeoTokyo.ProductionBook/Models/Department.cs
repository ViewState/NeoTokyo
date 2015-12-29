using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public String Name { get; set; }
        public Boolean Active { get; set; }
    }
}