using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Purchasing.Contracts;
using Purchasing.Entities.DTO;
using Purchasing.Entities.Models;
using Purchasing.Repository.RepositoryModels;



namespace Purchasing.Repository
{
    public class ServiceVendor: IServiceVendor
    {
        private readonly IRepositoryManager _repository;
        public ServiceVendor(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<bool> NewVendor(ProductVendorDto productVendorDto)
        {
            var businessEntity = new BusinessEntity();
            _repository.BusinessEntity.CreateBusinessEntityAsync(businessEntity);
            await _repository.SaveAsync();


            var vendor = new Vendor()
            {
                AccountNumber = productVendorDto.Vendor.AccountNumber,
                BusinessEntityID = businessEntity.BusinessEntityID,
                Name = productVendorDto.Vendor.Name,
                CreditRating = productVendorDto.Vendor.CreditRating,
                PreferredVendorStatus = productVendorDto.Vendor.PreferredVendorStatus,
                ActiveFlag = productVendorDto.Vendor.ActiveFlag,
                PurchasingWebServiceURL = productVendorDto.Vendor.PurchasingWebServiceURL,
                ModifiedDate = DateTime.Now

            };
            _repository.Vendor.CreateVendorAsync(vendor);
            await _repository.SaveAsync();
            var products = _repository.ProductVendor.GetAllProductVendorAsync(trackChanges: true).Result.Where(e => e.BusinessEntityID == businessEntity.BusinessEntityID);

            return true;
            
        }
    }
}
