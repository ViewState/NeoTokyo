using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class Process
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public String Name { get; set; }
        [Display(Name = "Is an Overnight Process")]
        public Boolean IsOvernightProcess { get; set; }
        [Display(Name = "Completed Status Text")]
        public String CompletedStatusText { get; set; }

        public virtual ICollection<DesignProcess> DesignProcesses { get; set; }
    }
}