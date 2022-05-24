using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing.Entities.Models;
using Purchasing.Entities.DTO;

namespace Purchasing.Contracts.Interfaces
{
    public interface IBusinessEntityRepository
    {
        Task<IEnumerable<BusinessEntity>> GetAllBusinessEntityAsync(bool trackChanges);
        Task<BusinessEntity> GetBusinessEntityAsync(int id, bool trackChanges);
        public void CreateBusinessEntityAsync(BusinessEntity businessEntity);
    }
}
