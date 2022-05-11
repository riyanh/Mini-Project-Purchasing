using Purchasing.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts
{
    public interface IRepositoryManager
    {
        //Modul-modul Crud
        IVendorRepository Vendor { get; }

        Task SaveAsync();
    }
}
