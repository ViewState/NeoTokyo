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
    
    public partial class UnitProcessStatusHistory
    {
        public System.Guid ID { get; set; }
        public System.Guid UnitProcessID { get; set; }
        public System.Guid UnitProcessStatusID { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual UnitProcess UnitProcess { get; set; }
        public virtual UnitProcessStatu UnitProcessStatu { get; set; }
    }
}