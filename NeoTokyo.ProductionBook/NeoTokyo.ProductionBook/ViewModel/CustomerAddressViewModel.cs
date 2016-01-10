using System;
using NeoTokyo.ProductionBook.CustomEnumTypes;
using NeoTokyo.ProductionBook.Models;

namespace NeoTokyo.ProductionBook.ViewModel
{
    public class CustomerAddressViewModel
    {
        public Guid ID{ get; set; }
        public Address Address { get; set; }
        public Boolean AsDefaultDelivery { get; set; }
        public Boolean AsDefaultInvoice { get; set; }
    }
}