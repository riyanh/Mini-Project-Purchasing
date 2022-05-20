using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class vPurchaseOrderVendor
    {
        public int BusinessEntityID { get; set; }
        public string ProductName { get; set; }
        public decimal StandardPrice { get; set; }
        public string UnitMeasureCode { get; set; }
        public string VendorName { get; set; }
        public int ProductID { get; set; }
        public int ProductPhotoID { get; set; }
    }
}
