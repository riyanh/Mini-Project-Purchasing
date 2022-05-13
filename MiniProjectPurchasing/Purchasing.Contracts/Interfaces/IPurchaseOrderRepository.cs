using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;

namespace Purchasing.Contracts.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<PurchaseOrderHeader>> GetAllPurchaseOrderAsync(bool trackChanges);

        //Task<PurchaseOrderHeader> GetVendorAsync(int id, bool trackChanges);

        //Task<IEnumerable<PurchaseOrderHeader>> GetPaginationVendorAsync(VendorParameters vendorParameters, bool trackChanges);

        //Task<IEnumerable<PurchaseOrderHeader>> GetSearchVendorAsync(VendorParameters vendorParameters, bool trackChanges);
    }
}
