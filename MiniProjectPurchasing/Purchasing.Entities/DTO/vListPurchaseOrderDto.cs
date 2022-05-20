﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class vListPurchaseOrderDto
    {
        public int BusinessEntityID { get; set; }
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
        
    }
}