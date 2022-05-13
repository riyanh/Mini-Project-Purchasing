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
        private IProductReceiptRepository _productReceiptRepository;

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

        public IProductReceiptRepository ProductReceipt
        {
            get
            {
                if (_productReceiptRepository == null)
                {
                    _productReceiptRepository = new ProductReceiptRepository(_repositoryContext);
                }
                return _productReceiptRepository;
            }
        }

        public async Task SaveAsync() =>
            await _repositoryContext.SaveChangesAsync();
    }
}
