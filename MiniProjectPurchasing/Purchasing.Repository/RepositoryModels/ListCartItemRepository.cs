using Microsoft.EntityFrameworkCore;
using Purchasing.Contracts.Interfaces;
using Purchasing.Entities.Models;
using Purchasing.Entities.RepositoryContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Repository.RepositoryModels
{
    public class ListCartItemRepository : RepositoryBase<VCartItem>, IListCartItemRepository
    {
        public ListCartItemRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<VCartItem>> GetAllListCartItemAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<VCartItem> GetListCartItemAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.PurchaseOrderID.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
    }
}
