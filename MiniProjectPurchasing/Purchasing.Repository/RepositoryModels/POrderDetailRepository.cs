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
    public class POrderDetailRepository : RepositoryBase<PurchaseOrderDetail>, IPOrderDetailRepository
    {
        public POrderDetailRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePOrderDetailsAsync(PurchaseOrderDetail purchaseOrderDetail)
        {
            Create(purchaseOrderDetail);
        }

        public void DeletePOrderDetailsAsync(PurchaseOrderDetail purchaseOrderDetail)
        {
            Create(purchaseOrderDetail);
        }

        public async Task<IEnumerable<PurchaseOrderDetail>> GetAllPODetailsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(o => o.PurchaseOrderDetailID)
                .ToListAsync();

        public async Task<PurchaseOrderDetail> GetPODetailsAsync(int productID, bool trackChanges) =>
             await FindByCondition(c => c.ProductID.Equals(productID), trackChanges).FirstOrDefaultAsync();

        public void UpdatePOrderDetailsAsync(PurchaseOrderDetail purchaseOrderDetail)
        {
            Update(purchaseOrderDetail);
        }
    }
}
