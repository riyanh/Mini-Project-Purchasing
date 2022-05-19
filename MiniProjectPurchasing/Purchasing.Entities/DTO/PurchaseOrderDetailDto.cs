using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.DTO
{
    public class PurchaseOrderDetailDto
    {
        public int PurchaseOrderID { get; set; }
       /* public DateTime DueDate { get; set; }
        public short OrderQty { get; set; }*/
        public int ProductID { get; set; }
        //public decimal UnitPrice { get; set; }
    }
}
