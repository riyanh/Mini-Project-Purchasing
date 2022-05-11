using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;

namespace Purchasing.Contracts.Interfaces
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllVendoryAsync(bool trackChanges);

        Task<Vendor> GetVendorAsync(int id, bool trackChanges);
    }
}
