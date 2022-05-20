using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchasing.Contracts;
using Purchasing.Entities.DTO;
using Purchasing.Entities.Models;
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
        private readonly IPurchaseOrderService _service;

        public PurchaseOrderController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IPurchaseOrderService service)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _service = service;
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

        [HttpPost("AddToChart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            try
            {
                var addToCarts = await _service.AddToCart(addToCartDto);
                if (!addToCarts)
                {
                    _logger.LogError("Add To Cart Purchase Order");
                    BadRequest("Add To Cart Purchase Order");
                } 
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(AddToCart)} message : {ex}");
                return StatusCode(500, $"Error {ex}");
            }
        }

    }
}
