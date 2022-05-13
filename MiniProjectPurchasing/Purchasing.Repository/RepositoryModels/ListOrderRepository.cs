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
    public class ListOrderRepository : RepositoryBase<PurchaseOrderHeader>, IListOrderRepository
    {
        public ListOrderRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<PurchaseOrderHeader>> GetAllListOrderAsync(bool trackChanges)=>
            await FindAll(trackChanges).OrderBy(v => v.PurchaseOrderID).ToListAsync();



        public Task<PurchaseOrderHeader> GetListOrderAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
