using Purchasing.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts.Interfaces
{
    public interface IPOrderDetailRepository
    {
        Task <IEnumerable<PurchaseOrderDetail>> GetAllPODetailsAsync(bool trackChanges);

        Task <PurchaseOrderDetail> GetPODetailsAsync(int purchaseOrderID, int productId, bool trackChanges);
        void CreatePOrderDetailsAsync(PurchaseOrderDetail purchaseOrderDetail);
        void DeletePOrderDetailsAsync(PurchaseOrderDetail purchaseOrderDetail);

        void UpdatePOrderDetailsAsync(PurchaseOrderDetail purchaseOrderDetail);
    }
}
