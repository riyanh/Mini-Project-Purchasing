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
    public class ProductReceiptRepository : RepositoryBase<VProductReceipt>, IProductReceiptRepository
    {
        public ProductReceiptRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<VProductReceipt>> GetAllProductReceiptAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(p => p.ProductID).ToListAsync();

        public async Task<IEnumerable<VProductReceipt>> GetSearchProductReceiptAsync(ProductReceiptParameters productReceiptParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(productReceiptParameters.SearchAccountingNumber) && string.IsNullOrWhiteSpace(productReceiptParameters.SearchName))
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            var accountingSearch = productReceiptParameters.SearchAccountingNumber.Trim().ToLower();
            var nameSearch = productReceiptParameters.SearchName.Trim().ToLower();
            return await FindAll(trackChanges)
                .Where(v => v.AccountNumber.ToLower().Contains(accountingSearch) && v.Name.ToLower().Contains(nameSearch))
                .ToListAsync();
        }

    }
}
