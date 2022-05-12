﻿using Microsoft.EntityFrameworkCore;
using Purchasing.Contracts.Interfaces;
using Purchasing.Entities.Models;
using Purchasing.Entities.RepositoryContexts;
using Purchasing.Entities.RequesFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.RequesFeatures;

namespace Purchasing.Repository.RepositoryModels
{
    public class VendorRepository : RepositoryBase<VListVendor>, IVendorRepository
    {
        public VendorRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public Task<IEnumerable<VListVendor>> GetAllVendoryAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VListVendor>> GetPaginationVendorAsync(VendorParameters vendorParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VListVendor>> GetSearchVendorAsync(VendorParameters vendorParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(vendorParameters.SearchVendor))
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            var lowerCaseSearch = vendorParameters.SearchVendor.Trim().ToLower();
            return await FindAll(trackChanges)
                //.Where(v => v.AccountNumber.ToLower().Contains(lowerCaseSearch))
                .Where(v => v.AccountNumber.ToLower().Contains(lowerCaseSearch) || v.Name.ToLower().Contains(lowerCaseSearch))
                .OrderBy(v => v.Name)
                .Skip((vendorParameters.PageNumber - 1) * vendorParameters.PageSize)
                .Take(vendorParameters.PageSize)
                .ToListAsync();
        }

        public Task<VListVendor> GetVendorAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        /* public async Task<IEnumerable<Vendor>> GetAllVendoryAsync(bool trackChanges) =>
             await FindAll(trackChanges).OrderBy(v => v.BusinessEntityID).ToListAsync();

         public Task<Vendor> GetVendorAsync(int id, bool trackChanges)
         {
             throw new NotImplementedException();
         }*/

        /* public async Task<IEnumerable<Vendor>> GetPaginationVendorAsync(VendorParameters vendorParameters, bool trackChanges)
         {
             return await FindAll(trackChanges)
                 .Skip((vendorParameters.PageNumber - 1) * vendorParameters.PageSize)
                 .Take(vendorParameters.PageSize)
                 .ToListAsync();
         }*/

        /* public async Task<IEnumerable<Vendor>> GetSearchVendorAsync(VendorParameters vendorParameters, bool trackChanges)
         {
             if (string.IsNullOrWhiteSpace(vendorParameters.SearchVendor))
             {
                 return await FindAll(trackChanges).ToListAsync();
             }
             var lowerCaseSearch = vendorParameters.SearchVendor.Trim().ToLower();
             return await FindAll(trackChanges)
                 //.Where(v => v.AccountNumber.ToLower().Contains(lowerCaseSearch))
                 .Where(v => v.AccountNumber.ToLower().Contains(lowerCaseSearch) || v.Name.ToLower().Contains(lowerCaseSearch))
                 .OrderBy(v => v.Name)
                 .Skip((vendorParameters.PageNumber - 1) * vendorParameters.PageSize)
                 .Take(vendorParameters.PageSize)
                 .ToListAsync();
         }*/
    }
}
