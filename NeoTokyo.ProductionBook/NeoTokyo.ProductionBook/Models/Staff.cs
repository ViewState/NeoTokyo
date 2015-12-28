using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoTokyo.ProductionBook.Models
{
    public class Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Display(Name = "Middle name")]
        public String MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        public Boolean Active { get; set; }

        [Display(Name = "Full Name")]
        public String FullName =>
            $"{FirstName}{(String.IsNullOrEmpty(MiddleName) ? " " : $" {MiddleName} ")}{LastName}";

        public virtual StaffResourceGroupLink StaffResourceGroupLink { get; set; }
        public virtual Designer Designer { get; set; }
    }
}