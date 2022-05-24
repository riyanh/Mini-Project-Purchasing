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
        void CreateVendorAsync(Vendor vendor);
        void DeleteVendorAsync(Vendor vendor);
        void UpdateVendorasync(Vendor vendor);
    }
}
