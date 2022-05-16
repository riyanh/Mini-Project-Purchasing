using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class TotalDueMonthDto
    {
        public string Months { get; set; }
        public decimal? TotalDue { get; set; }
    }
}
