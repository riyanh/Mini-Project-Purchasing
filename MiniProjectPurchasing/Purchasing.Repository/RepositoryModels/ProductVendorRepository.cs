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
    public class ProductVendorRepository : RepositoryBase<vPurchaseOrderVendor>, IProductVendorRepository
    {
        public ProductVendorRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<vPurchaseOrderVendor>> GetAllProductVendorAsync(bool trackChanges) =>
           await FindAll(trackChanges).OrderBy(v => v.BusinessEntityID).ToListAsync();

        public Task<vPurchaseOrderVendor> GetProductVendorAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
