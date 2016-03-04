using System;
using System.ComponentModel.DataAnnotations;

namespace ViewState.ProcessScheduler.ViewModels
{
    public class StaffWithDesignerViewModel
    {
        public Guid ID { get; set; }
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public String MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        public Boolean Active { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Is A Designer")]
        public Boolean IsDesigner { get; set; }
    }
}
