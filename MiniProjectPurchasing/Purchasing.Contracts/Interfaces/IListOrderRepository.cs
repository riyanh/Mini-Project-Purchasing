using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;

namespace Purchasing.Contracts.Interfaces
{
    public interface IListOrderRepository
    {
        Task<IEnumerable<PurchaseOrderHeader>> GetAllListOrderAsync(bool trackChanges);

        Task<PurchaseOrderHeader> GetListOrderAsync(int id, bool trackChanges);

    }
}
