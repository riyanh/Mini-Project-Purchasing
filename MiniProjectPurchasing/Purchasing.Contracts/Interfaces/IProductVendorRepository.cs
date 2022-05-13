using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;

namespace Purchasing.Contracts.Interfaces
{
    public interface IProductVendorRepository
    {
        Task<IEnumerable<ProductVendor>> GetAllProductVendorAsync(bool trackChanges);

        Task<ProductVendor> GetProductVendorAsync(int id, bool trackChanges);
    }
}
