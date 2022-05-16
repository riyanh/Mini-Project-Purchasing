using System;
using System.Collections.Generic;

#nullable disable

namespace Purchasing.Entities.Models
{
    public partial class VTotalDueMonth
    {
        public string Months { get; set; }
        public decimal? TotalDue { get; set; }
    }
}
