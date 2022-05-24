using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Contracts.Interfaces;
using Purchasing.Entities.DTO;
using Purchasing.Entities.Models;
using Purchasing.Entities.RepositoryContexts;

namespace Purchasing.Repository.RepositoryModels
{
    public class ProductVendorHRepository : RepositoryBase<ProductVendor>, IProductVendorHRepository
    {
        public ProductVendorHRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateProductVendorHAsync(ProductVendor productVendor)
        {
            Create(productVendor);
        }
    }
}
