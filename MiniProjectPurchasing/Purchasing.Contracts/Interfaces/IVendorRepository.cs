using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;
using Purchasing.Entities.RequesFeatures;

namespace Purchasing.Contracts.Interfaces
{
    public interface IVendorRepository
    {
        Task<IEnumerable<VListVendor>> GetAllVendoryAsync(bool trackChanges);

        Task<VListVendor> GetVendorAsync(int id, bool trackChanges);

        Task<IEnumerable<VListVendor>> GetPaginationVendorAsync(VendorParameters vendorParameters, bool trackChanges);

        Task<IEnumerable<VListVendor>> GetSearchVendorAsync(VendorParameters vendorParameters, bool trackChanges);
    }
}
