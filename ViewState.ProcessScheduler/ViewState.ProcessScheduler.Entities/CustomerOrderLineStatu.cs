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
    
    public partial class CustomerOrderLineStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerOrderLineStatu()
        {
            this.CustomerOrderLineStatusHistories = new HashSet<CustomerOrderLineStatusHistory>();
        }
    
        public System.Guid ID { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int StatusOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerOrderLineStatusHistory> CustomerOrderLineStatusHistories { get; set; }
    }
}
