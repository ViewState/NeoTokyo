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
    
    public partial class Allocation
    {
        public System.Guid ID { get; set; }
        public System.Guid UnitProcessID { get; set; }
        public System.Guid ResourceGroupID { get; set; }
        public System.DateTime EstimatedStartDate { get; set; }
        public System.DateTime EstimatedEndDate { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual ResourceGroup ResourceGroup { get; set; }
        public virtual UnitProcess UnitProcess { get; set; }
    }
}
