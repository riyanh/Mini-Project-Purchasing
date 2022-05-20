using Purchasing.Entities.Models;
using Purchasing.Entities.RequesFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<VPurchaseOrder>> GetAllPurchaseOrderAsync(bool trackChanges);
        Task<VPurchaseOrder> GetPuchaseOrdersAsync(int productID, bool trackChanges);
        Task<IEnumerable<VPurchaseOrder>> GetSearchPurchaseOrderAsync(PurchaseOrderParameters purchaseOrderParameters, bool trackChanges);

    }
}
