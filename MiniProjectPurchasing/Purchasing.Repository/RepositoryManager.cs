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

        public async Task SaveAsync() =>
            await _repositoryContext.SaveChangesAsync();
    }
}
