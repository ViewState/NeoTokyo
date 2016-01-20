using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class CustomerOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }

        [Display(Name = "PO Number")]
        public String CustomerPONumber { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMMM/yyyy}")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public String Comments { get; set; }

        [Display(Name = "Current Status")]
        [ForeignKey("CustomerOrderStatus")]
        public Guid CustomerOrderStatusID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerOrderStatus CustomerOrderStatus { get; set; }
        public virtual ICollection<CustomerOrderStatusHistory> CustomerOrderStatusHistorys { get; set; }

    }
}