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
    
    public partial class Process
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Process()
        {
            this.DesignProcesses = new HashSet<DesignProcess>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public bool IsOverNightProcess { get; set; }
        public string CompletedStatusText { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DesignProcess> DesignProcesses { get; set; }
    }
}
