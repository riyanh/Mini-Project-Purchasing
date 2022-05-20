using Purchasing.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts.Interfaces
{
    public interface IPOrderHeaderRepository
    {
        Task<IEnumerable<PurchaseOrderHeader>> GetAllPOHeadersAsync(bool trackChanges);

        Task<PurchaseOrderHeader> GetPOHeaderAsync(int employeeID, bool trackChanges);
        void CreatePOrderHeaderAsync(PurchaseOrderHeader purchaseOrderHeader);
        void DeletePOrderHeaderAsync(PurchaseOrderHeader purchaseOrderDetail);

        void UpdatePOrderHeaderAsync(PurchaseOrderHeader purchaseOrderDetail);
    }
}
