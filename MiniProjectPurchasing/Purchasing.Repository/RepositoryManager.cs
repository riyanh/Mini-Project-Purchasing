using Purchasing.Contracts;
using Purchasing.Contracts.Interfaces;
using Purchasing.Entities.RepositoryContexts;
using Purchasing.Repository.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private AdventureWorks2019Context _repositoryContext;
        private IVendorRepository _vendorRepository;
        private IProductVendorRepository _productVendorRepository;
        private IListOrderRepository _listOrderRepository;
        private IBusinessEntityRepository _businessEntityRepository;
        private IProductRepository _productRepository;
        private IProductVendorHRepository _productVendorHRepository;
        private IUnitMeasureRepository _unitMeasureRepository;
        private IShipMethodRepository _shipMethodRepository;

        public RepositoryManager(AdventureWorks2019Context repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IVendorRepository Vendor
        {
            get
            {
                if (_vendorRepository == null)
                {
                    _vendorRepository = new VendorRepository(_repositoryContext);
                }
                return _vendorRepository;
            }
        }

        public IProductVendorRepository ProductVendor
        {
            get
            {
                if (_productVendorRepository == null)
                {
                    _productVendorRepository = new ProductVendorRepository(_repositoryContext);
                }
                return _productVendorRepository;
            }
        }
        public IListOrderRepository ListOrder
        {
            get
            {
                if (_listOrderRepository == null)
                {
                    _listOrderRepository = new ListOrderRepository(_repositoryContext);
                }
                return _listOrderRepository;
            }
        }

        public IBusinessEntityRepository BusinessEntity
        {
            get
            {
                if (_businessEntityRepository == null)
                {
                    _businessEntityRepository = new BusinessEntityRepository(_repositoryContext);
                }
                return _businessEntityRepository;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_repositoryContext);
                }
                return _productRepository;
            }
        }
        public IShipMethodRepository ShipMethod
        {
            get
            {
                if(_shipMethodRepository == null)
                {
                    _shipMethodRepository = new ShipMethodRepository(_repositoryContext);
                }
                return (_shipMethodRepository);
            }
        }
        public IProductVendorHRepository ProductVendorH
        {
            get
            {
                if (_productVendorHRepository == null)
                {
                    _productVendorHRepository = new ProductVendorHRepository(_repositoryContext);
                }
                return _productVendorHRepository;
            }
        }

        public async Task SaveAsync() =>
            await _repositoryContext.SaveChangesAsync();
    }
}
