using System;

namespace ViewState.ProcessScheduler.ViewModels
{
    public class CountryViewModel
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public DateTime DateCreated { get; set; }
        public Boolean Active { get; set; }
    }
}
