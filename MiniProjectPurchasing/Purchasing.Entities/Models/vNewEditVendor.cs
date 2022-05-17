using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class vNewEditVendor
    {
        public string AccountNumber { get; set; }
        public int BusinessEntityID { get; set; }
        public string VendorName { get; set; }
        public string PurchasingWebServiceURL { get; set; }
        public bool PreferredVendorStatus { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ProductID { get; set; }
        public decimal StandardPrice { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }
        public string UnitMeasureCode { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public short SafetyStockLevel { get; set; }
    }
}
