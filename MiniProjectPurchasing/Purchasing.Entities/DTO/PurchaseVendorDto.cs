using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class PurchaseVendorDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string UnitMeasure { get; set; }

        public int AvailableStock { get; set; }
        public string Vendor { get; set; }
    }
}
