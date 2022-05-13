using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Entities.RequesFeatures
{
    public class ProductReceiptParameters : RequestParameters
    {
        public string SearchAccountingNumber { get; set; }
        public string SearchName { get; set; }
    }
}
