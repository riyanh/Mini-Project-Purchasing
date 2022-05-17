using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class ListCartItemDto
    {
        public int PurchaseOrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
    }
}
