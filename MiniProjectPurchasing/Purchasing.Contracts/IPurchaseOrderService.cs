using Purchasing.Entities.DTO;
using Purchasing.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrderDetail> AddToCart(int purchaseOrderDetailID, int productQty);
        //Task<bool> AddToCart(PurchaseOrderDetailDto purchaseOrderDetailDto);
    }
}
