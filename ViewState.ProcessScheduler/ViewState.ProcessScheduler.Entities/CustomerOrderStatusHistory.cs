//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViewState.ProcessScheduler.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerOrderStatusHistory
    {
        public System.Guid ID { get; set; }
        public System.Guid CustomerOrderStatusID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.Guid CustomerOrderID { get; set; }
    
        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual CustomerOrderStatu CustomerOrderStatu { get; set; }
    }
}
