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
    public class StatusOrderRepository : RepositoryBase<VStatusTotalOrder>, IStatusOrderRepository
    {
        public StatusOrderRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<VStatusTotalOrder>> GetSearchStatusTotalVendorAsync(StatusOrderParameters statusOrderParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(statusOrderParameters.SearchStatusVendor))
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            var lowerCaseSearch = statusOrderParameters.SearchStatusVendor.Trim().ToLower();
                return await FindAll(trackChanges)
                .Where(v => v.AccountNumber.ToLower().Contains(lowerCaseSearch))
                .OrderBy(v => v.AccountNumber)
                .ToListAsync();
        }

        public async Task<IEnumerable<VStatusTotalOrder>> GetStatusTotalOrderAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(ps => ps.AccountNumber).ToListAsync();
        
    }
}
