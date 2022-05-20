using Microsoft.EntityFrameworkCore;
using Purchasing.Contracts.Interfaces;
using Purchasing.Entities.Models;
using Purchasing.Entities.RepositoryContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.RequesFeatures;

namespace Purchasing.Repository.RepositoryModels
{
    public class ListOrderRepository : RepositoryBase<vListPurchaseOrder>, IListOrderRepository
    {
        public ListOrderRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<vListPurchaseOrder>> GetAllListOrderAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(v => v.PurchaseOrderID).ToListAsync();
        }
        public async Task<vListPurchaseOrder> GetListOrderAsync(int id, bool trackChanges)=>
            await FindByCondition(v => v.PurchaseOrderID.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<vListPurchaseOrder>> GetPaginationListOrderAsync(ListOrderParameters listOrderParameters, bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(v => v.PurchaseOrderID).Skip((listOrderParameters.PageNumber - 1) * listOrderParameters.PageSize).Take(listOrderParameters.PageSize).ToListAsync();


    }
}
