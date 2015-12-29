using System;

namespace NeoTokyo.ProductionBook.ViewModel
{
    public class StaffResourceGroupViewModel
    {
        public Guid ID { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public Boolean Active { get; set; }
        public Guid? ResourceGroupID { get; set; }
        public String ResourceGroupName { get; set; }
        public Boolean IsDesigner { get; set; }
    }
}