using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;

namespace Purchasing.Contracts.Interfaces
{
    public interface IShipMethodRepository
    {
        Task<IEnumerable<ShipMethod>> GetAllShipMethodAsync(bool trackChanges);
    }
}
