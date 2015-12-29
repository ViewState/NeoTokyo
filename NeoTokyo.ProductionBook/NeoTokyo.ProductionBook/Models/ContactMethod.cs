using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class ContactMethod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Display(Name = "Contact Type")]
        public Int16 ContactType { get; set; }
        [Display(Name = "Details")]
        public String ContactTypeDetails { get; set; }
        public Boolean Active { get; set; }
    }

    public enum ContactType
    {
        Telephone,
        Email,
    }
}