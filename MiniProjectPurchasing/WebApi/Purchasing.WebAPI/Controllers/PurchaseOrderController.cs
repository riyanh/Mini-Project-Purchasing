using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchasing.Contracts;
using Purchasing.Entities.DTO;
using Purchasing.Entities.RequesFeatures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Purchasing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PurchaseOrderController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("listProduct")]
        public async Task<IActionResult> GetPurchaseOrder()
        {
            try
            {
                var purchaseOrderVendor = await _repository.PurchaseOrder.GetAllPurchaseOrderAsync(trackChanges: false);

                var purchaseOrderDto = _mapper.Map<IEnumerable<PurchaseOrderDto>>(purchaseOrderVendor);

                return Ok(purchaseOrderDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetPurchaseOrder)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }//EndMethodGet

        [HttpGet("search")]
        public async Task<IActionResult> GetPurchaseOrderSearch([FromQuery] PurchaseOrderParameters purchaseOrderParameters)
        {
            var purchaseOrderSearch = await _repository.PurchaseOrder.GetSearchPurchaseOrderAsync(purchaseOrderParameters, trackChanges: false);
            var purchaseOrderDto = _mapper.Map<IEnumerable<PurchaseOrderDto>>(purchaseOrderSearch);
            return Ok(purchaseOrderDto);
        }//endMethodSearch

    }
}
