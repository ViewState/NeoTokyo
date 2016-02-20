using System;

namespace ViewState.ProcessScheduler.ViewModels
{
    public class AddressViewModel
    {
        public Guid ID { get; set; }
        public String AddressName { get; set; }
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String Town { get; set; }
        public String County { get; set; }
        public Guid CountryID { get; set; }
        public String PostCode { get; set; }
        public DateTime DateCreated { get; set; }
        public Boolean Active { get; set; }
    }
}
