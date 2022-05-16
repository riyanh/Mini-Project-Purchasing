using Microsoft.EntityFrameworkCore;
using Purchasing.Contracts;
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
    public class ApprovedVendorRepository : RepositoryBase<VApprovedVendor>, IApprovedVendorRepository
    {
        public ApprovedVendorRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<VApprovedVendor>> GetTotalApprovedAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(v => v.Vendor).ToListAsync();
        
    }
}
