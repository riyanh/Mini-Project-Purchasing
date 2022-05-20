using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;
using Purchasing.Entities.RequesFeatures;

namespace Purchasing.Contracts.Interfaces
{
    public interface IListOrderRepository
    {
        Task<IEnumerable<vListPurchaseOrder>> GetAllListOrderAsync(bool trackChanges);

        Task<vListPurchaseOrder> GetListOrderAsync(int id, bool trackChanges);
        Task<IEnumerable<vListPurchaseOrder>> GetPaginationListOrderAsync(ListOrderParameters listOrderParameters, bool trackChanges);

    }
}
