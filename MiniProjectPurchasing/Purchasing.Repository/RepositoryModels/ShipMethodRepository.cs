using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;
using Purchasing.Contracts.Interfaces;
using Purchasing.Entities.RepositoryContexts;
using Microsoft.EntityFrameworkCore;

namespace Purchasing.Repository.RepositoryModels
{
    public class ShipMethodRepository : RepositoryBase<ShipMethod>, IShipMethodRepository
    {
        public ShipMethodRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<ShipMethod>> GetAllShipMethodAsync(bool trackChanges)=>
        
            await FindAll(trackChanges).OrderBy(s => s.ShipMethodID).ToListAsync();
    }
}
