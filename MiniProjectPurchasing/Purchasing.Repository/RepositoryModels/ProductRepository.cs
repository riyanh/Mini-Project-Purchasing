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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task <IEnumerable<Product>> GetAllProductAsync(bool trackChanges)=>
            await FindAll(trackChanges).OrderBy(p => p.ProductID).ToListAsync();
    }
}
