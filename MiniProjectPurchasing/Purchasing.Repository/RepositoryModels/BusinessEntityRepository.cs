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
    public class BusinessEntityRepository : RepositoryBase<BusinessEntity>, IBusinessEntityRepository
    {
        public BusinessEntityRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateBusinessEntityAsync(BusinessEntity businessEntity)
        {
            Create(businessEntity);
        }

        public void DeleteBusinessEntityAsync(BusinessEntity businessEntity)
        {
            Delete(businessEntity);
        }

        public async Task<IEnumerable<BusinessEntity>> GetAllBusinessEntityAsync(bool trackChanges)=>
            await FindAll(trackChanges).OrderBy(c => c.BusinessEntityID).ToListAsync();

        public async Task<BusinessEntity> GetBusinessEntityAsync(int id, bool trackChanges)=>
            await FindByCondition(c => c.BusinessEntityID.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateBusinessEntityAsync(BusinessEntity businessEntity)
        {
            Update(businessEntity);
        }
    }
}
