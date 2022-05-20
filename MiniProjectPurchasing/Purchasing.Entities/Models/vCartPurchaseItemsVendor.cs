using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class vCartPurchaseItemsVendor
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseOrderDetailID { get; set; }
        public DateTime OrderDate { get; set; }
        public string AccountNumber { get; set; }
        public string VendorName { get; set; }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public int ShipMethodID { get; set; }
        public string ShipName { get; set; }
        public decimal ShipBase { get; set; }
        public decimal ShipRate { get; set; }
        public DateTime? ShipDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
    }
}
