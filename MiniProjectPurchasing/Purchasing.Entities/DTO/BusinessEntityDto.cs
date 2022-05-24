using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Purchasing.Entities.DTO
{
    public class BusinessEntityDto
    {
        public int BusinessEntityID { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
