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
    
    public partial class Design
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Design()
        {
            this.CustomerOrderLines = new HashSet<CustomerOrderLine>();
            this.DesignProcesses = new HashSet<DesignProcess>();
            this.WorksOrders = new HashSet<WorksOrder>();
        }
    
        public System.Guid ID { get; set; }
        public System.Guid DesignerID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool Active { get; set; }
        public string DesignNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerOrderLine> CustomerOrderLines { get; set; }
        public virtual Designer Designer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DesignProcess> DesignProcesses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorksOrder> WorksOrders { get; set; }
    }
}
