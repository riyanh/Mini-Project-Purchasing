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
        public decimal StandardPrice { get; set; }
        public string UnitMeasureCode { get; set; }
    }
}
