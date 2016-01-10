using System;
using NeoTokyo.ProductionBook.Models;

namespace NeoTokyo.ProductionBook.ViewModel
{
    public class CustomerAddressLinkViewModel
    {
        public CustomerAddressLink CustomerAddressLink { get; set; }
        public Boolean IsDefaultDeliveryAddress { get; set; }
        public Boolean IsDefaultInvoiceAddress { get; set; }
    }
}