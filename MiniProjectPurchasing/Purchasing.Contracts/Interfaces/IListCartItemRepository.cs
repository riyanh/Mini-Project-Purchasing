using Purchasing.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts.Interfaces
{
    public interface IListCartItemRepository
    {
        Task<IEnumerable<VCartItem>> GetAllListCartItemAsync(bool trackChanges);

        Task<VCartItem> GetListCartItemAsync(int id, bool trackChanges);
    }
}
