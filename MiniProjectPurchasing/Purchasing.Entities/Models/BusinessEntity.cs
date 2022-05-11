using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class BusinessEntity
    {
        public int BusinessEntityID { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
