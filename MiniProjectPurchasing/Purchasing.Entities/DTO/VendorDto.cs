using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class VendorDto
    {
        public int BusinessEntityID { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public byte CreditRating { get; set; }
        public bool? PreferredVendorStatus { get; set; }
        public bool? ActiveFlag { get; set; }
    }
}
