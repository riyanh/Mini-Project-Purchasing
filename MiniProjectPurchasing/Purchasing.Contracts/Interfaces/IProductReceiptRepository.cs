using Purchasing.Entities.Models;
using Purchasing.Entities.RequesFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts.Interfaces
{
    public interface IProductReceiptRepository
    {
        Task<IEnumerable<VProductReceipt>> GetAllProductReceiptAsync(bool trackChanges);

        Task<IEnumerable<VProductReceipt>> GetSearchProductReceiptAsync(ProductReceiptParameters productReceiptParameters, bool trackChanges);
    }
}
