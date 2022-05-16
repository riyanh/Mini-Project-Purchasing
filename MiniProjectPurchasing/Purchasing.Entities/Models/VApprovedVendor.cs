using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class VApprovedVendor
    {
        public string Vendor { get; set; }
        public int? Approved { get; set; }
    }
}
