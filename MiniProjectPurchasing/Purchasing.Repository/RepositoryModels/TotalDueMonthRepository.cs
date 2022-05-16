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
    public class TotalDueMonthRepository : RepositoryBase<VTotalDueMonth>, ITotalDueMonth
    {
        public TotalDueMonthRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<VTotalDueMonth>> GetTotalDueMonthAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(poh => poh.Months).ToListAsync();
    }
}
