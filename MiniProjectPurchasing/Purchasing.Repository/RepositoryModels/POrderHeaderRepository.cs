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
    public class POrderHeaderRepository : RepositoryBase<PurchaseOrderHeader>, IPOrderHeaderRepository
    {
        public POrderHeaderRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreatePOrderHeaderAsync(PurchaseOrderHeader purchaseOrderHeader)
        {
            Create(purchaseOrderHeader);
        }

        public void DeletePOrderHeaderAsync(PurchaseOrderHeader purchaseOrderDetail)
        {
            Delete(purchaseOrderDetail);
        }

        public async Task<IEnumerable<PurchaseOrderHeader>> GetAllPOHeadersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(h => h.PurchaseOrderID)
                .ToListAsync();
        }

        public async Task<PurchaseOrderHeader> GetPOHeaderAsync(int employeeID, bool trackChanges) =>
             await FindByCondition(h => h.EmployeeID.Equals(employeeID), trackChanges).FirstOrDefaultAsync();


        public void UpdatePOrderHeaderAsync(PurchaseOrderHeader purchaseOrderDetail)
        {
            Update(purchaseOrderDetail);
        }
    }
}
