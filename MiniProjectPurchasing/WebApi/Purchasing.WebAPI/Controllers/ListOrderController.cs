using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchasing.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purchasing.Entities.DTO;
using System;

namespace Purchasing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListOrderController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ListOrderController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOrder()
        {
            try
            {
                var listorders = await _repository.ListOrder.GetAllListOrderAsync(trackChanges: false);

                var purchaseOrderHeaderDto = _mapper.Map<IEnumerable<PurchaseOrderHeaderDto>>(listorders);

                return Ok(purchaseOrderHeaderDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetListOrder)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }//EndMethodGetVendor

    }//endClassVendor
}
