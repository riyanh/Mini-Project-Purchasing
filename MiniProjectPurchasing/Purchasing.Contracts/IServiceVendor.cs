using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;
using Purchasing.Entities.DTO;

namespace Purchasing.Contracts
{
    public interface IServiceVendor
    {
        Task<bool> NewVendor(ProductVendorDto productVendorDto);
    }
}
