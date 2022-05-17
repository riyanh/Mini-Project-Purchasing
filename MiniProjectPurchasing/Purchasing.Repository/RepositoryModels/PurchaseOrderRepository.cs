using Microsoft.EntityFrameworkCore;
using Purchasing.Contracts.Interfaces;
using Purchasing.Entities.Models;
using Purchasing.Entities.RepositoryContexts;
using Purchasing.Entities.RequesFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Repository.RepositoryModels
{
    public class PurchaseOrderRepository : RepositoryBase<VPurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<VPurchaseOrder>> GetAllPurchaseOrderAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<IEnumerable<VPurchaseOrder>> GetSearchPurchaseOrderAsync(PurchaseOrderParameters purchaseOrderParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(purchaseOrderParameters.SearchProduct))
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            var lowerCaseSearch = purchaseOrderParameters.SearchProduct.Trim().ToLower();
            return await FindAll(trackChanges)
                .Where(p => p.AccountNumber.ToLower().Contains(lowerCaseSearch) ||
                p.vendor.ToLower().Contains(lowerCaseSearch) ||
                p.product.ToLower().Contains(lowerCaseSearch))
                .OrderBy(c => c.AccountNumber)
                .Skip((purchaseOrderParameters.PageNumber - 1) * purchaseOrderParameters.PageSize)
                .Take(purchaseOrderParameters.PageSize)
                .ToListAsync();
        }
    }
}
