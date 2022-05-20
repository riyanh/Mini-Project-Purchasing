using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class VPurchaseOrder
    {
        public int ShipMethodID { get; set; }
        public int ProductID { get; set; }
        public int BusinessEntityID { get; set; }
        public string AccountNumber { get; set; }
        public string product { get; set; }
        public int? OnOrderQty { get; set; }
        public string vendor { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitMeasureCode { get; set; }
    }
}
