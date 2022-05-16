using Purchasing.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purchasing.Contracts.Interfaces
{
    public interface ITotalDueMonth
    {
        Task<IEnumerable<VTotalDueMonth>> GetTotalDueMonthAsync(bool trackChanges);
    }
}
