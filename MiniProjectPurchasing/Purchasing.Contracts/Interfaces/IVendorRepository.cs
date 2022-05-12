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
        Task<IEnumerable<Vendor>> GetAllVendoryAsync(bool trackChanges);

        Task<Vendor> GetVendorAsync(int id, bool trackChanges);

        Task<IEnumerable<Vendor>> GetPaginationVendorAsync(VendorParameters vendorParameters, bool trackChanges);

        Task<IEnumerable<Vendor>> GetSearchVendorAsync(VendorParameters vendorParameters, bool trackChanges);
    }
}
