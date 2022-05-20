using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class vPurchaseOrderVendorDto
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
