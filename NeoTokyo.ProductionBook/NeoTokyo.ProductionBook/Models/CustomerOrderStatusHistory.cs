using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{

    public class CustomerOrderStatusHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("CustomerOrder")]
        public Guid CustomerOrderID { get; set; }

        [ForeignKey("CustomerOrderStatus")]
        public Guid CustomerOrderStatusID { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual CustomerOrderStatus CustomerOrderStatus { get; set; }
    }
}