using System;

namespace ViewState.ProcessScheduler.ViewModels
{
    public class ProcessViewModel
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public Boolean IsOverNightProcess { get; set; }
        public String CompletedStatusText { get; set; }
        public DateTime DateCreated { get; set; }
        public Boolean Active { get; set; }

    }
}
