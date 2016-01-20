using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class CustomerOrderStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public String Status { get; set; }

        public String Description { get; set; }

        public int Order { get; set; }

        public bool Finished { get; set; }

        public virtual ICollection<CustomerOrderStatusHistory> CustomerOrderStatusHistorys { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}