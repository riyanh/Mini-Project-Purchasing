using Purchasing.Entities.Models;
using Purchasing.Entities.RequesFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts.Interfaces
{
    public interface IStatusOrderRepository
    {
        Task<IEnumerable<VStatusTotalOrder>> GetStatusTotalOrderAsync(bool trackChanges);

        Task<IEnumerable<VStatusTotalOrder>> GetSearchStatusTotalVendorAsync(StatusOrderParameters statusOrderParameters, bool trackChanges);
    }
}
