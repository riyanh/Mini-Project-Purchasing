using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class vListPurchaseOrder
    {
        public int PurchaseOrderID { get; set; }
        public byte Status { get; set; }
        public string VendorName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public int EmployeeID { get; set; }
        public byte RevisionNumber { get; set; }
        public int BusinessEntityID { get; set; }
    }
}
