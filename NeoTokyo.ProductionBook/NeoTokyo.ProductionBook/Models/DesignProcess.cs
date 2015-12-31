using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class DesignProcess
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [ForeignKey("Design")]
        public Guid DesignID { get; set; }
        [ForeignKey("Process")]
        public Guid ProcessID { get; set; }
        [ForeignKey("Department")]
        public Guid DepartmentID { get; set; }
        public Int32 ProcessTime { get; set; }
        public Int32 ProcessOrder { get; set; }

        public virtual Design Design { get; set; }
        public virtual Process Process { get; set; }
        public virtual Department Department { get; set; }
    }
}