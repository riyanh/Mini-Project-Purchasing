using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class VStatusTotalOrder
    {
        public string StatusVendor { get; set; }
        public int? TotalOrder { get; set; }
        public string AccountNumber { get; set; }
    }
}
