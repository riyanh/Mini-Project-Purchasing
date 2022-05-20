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
    public class VendorRepository : RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateVendorAsync(Vendor vendor)
        {
            Create(vendor);
        }

        public void DeleteVendorAsync(Vendor vendor)
        {
            Delete(vendor);
        }

        public async Task<IEnumerable<Vendor>> GetAllVendoryAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(v => v.BusinessEntityID).ToListAsync();

        public async Task<Vendor> GetVendorAsync(int id, bool trackChanges)=>
            await FindByCondition(v => v.BusinessEntityID.Equals(id), trackChanges).SingleOrDefaultAsync();
        public void UpdateVendorasync(Vendor vendor)
        {
            Update(vendor);
        }
    }
}
