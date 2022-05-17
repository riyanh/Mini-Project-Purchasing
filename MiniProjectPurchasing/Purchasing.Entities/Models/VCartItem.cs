using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class VCartItem
    {
        public int PurchaseOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
    }
}
