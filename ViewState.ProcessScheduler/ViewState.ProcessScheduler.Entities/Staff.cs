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
    
    public partial class Staff
    {
        public System.Guid ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual Designer Designer { get; set; }
        public virtual StaffResourceGroupLink StaffResourceGroupLink { get; set; }
    }
}
