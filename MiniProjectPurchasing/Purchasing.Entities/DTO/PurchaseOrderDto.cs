using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class PurchaseOrderDto
    {
        public string product { get; set; }
        public int? OnOrderQty { get; set; }
        public string vendor { get; set; }
        public decimal UnitPrice { get; set; }
        public string UnitMeasureCode { get; set; }
    }
}
