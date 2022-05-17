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
        private IApprovedVendorRepository _approvedVendorRepository;
        private IStatusOrderRepository _statusOrderRepository;
        private ITotalDueMonth _totalDueMonth;
        private IListCartItemRepository _cartItemRepository;
        private IPurchaseOrderRepository _purchaseOrderRepository;

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

        public IApprovedVendorRepository ApprovedVendor
        {
            get
            {
                if (_approvedVendorRepository == null)
                {
                    _approvedVendorRepository = new ApprovedVendorRepository(_repositoryContext);
                }
                return _approvedVendorRepository;
            }
        }

        public IStatusOrderRepository StatusOrder
        {
            get
            {
                if (_statusOrderRepository == null)
                {
                    _statusOrderRepository = new StatusOrderRepository(_repositoryContext);
                }
                return _statusOrderRepository;
            }
        }

        public ITotalDueMonth TotalDueMonth
        {
            get
            {
                if (_totalDueMonth == null)
                {
                    _totalDueMonth = new TotalDueMonthRepository(_repositoryContext);
                }
                return _totalDueMonth;
            }
        }

        public IListCartItemRepository ListCartItem
        {
            get
            {
                if (_cartItemRepository == null)
                {
                    _cartItemRepository = new ListCartItemRepository(_repositoryContext);
                }
                return _cartItemRepository;
            }
        }

        public IPurchaseOrderRepository PurchaseOrder
        {
            get
            {
                if (_purchaseOrderRepository == null)
                {
                    _purchaseOrderRepository = new PurchaseOrderRepository(_repositoryContext);
                }
                return _purchaseOrderRepository;
            }
        }

        public async Task SaveAsync() =>
            await _repositoryContext.SaveChangesAsync();
    }
}
