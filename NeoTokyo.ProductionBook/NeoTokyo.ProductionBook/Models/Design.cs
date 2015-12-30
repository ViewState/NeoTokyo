using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class Design
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("Designer")]
        public Guid DesignerID { get; set; }
        [Display(Name = "Date Created")]
        public DateTime Created { get; set; }
        public Boolean Active { get; set; }
        [Display(Name = "Design Number")]
        public String DesignNumber { get; set; }

        public virtual Designer Designer { get; set; }
    }
}