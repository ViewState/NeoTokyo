using System;
using System.ComponentModel.DataAnnotations;

namespace ViewState.ProcessScheduler.ViewModels
{
    public class DepartmentViewModel
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public Boolean Active { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

    }
}
