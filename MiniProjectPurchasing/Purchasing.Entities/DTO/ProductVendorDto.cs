using Purchasing.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class ProductVendorDto
    {
        public int ProductID { get; set; }
        public int BusinessEntityID { get; set; }

        public VendorDto Vendor { get; set; }

        /*public decimal StandardPrice { get; set; }
        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }
        public string UnitMeasureCode { get; set; }*/
        public ICollection<ProductVendor> ProductVendors {get;set;}
}
}
