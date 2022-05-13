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
    public class ProductReceiptController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductReceiptController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductReceipt()
        {
            try
            {
                var productReceipts = await _repository.ProductReceipt.GetAllProductReceiptAsync(trackChanges: false);

                var productReceiptsDto = _mapper.Map<IEnumerable<ProductReceiptDto>>(productReceipts);

                return Ok(productReceiptsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetProductReceipt)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }//EndMethodGetVendor

        [HttpGet("search")]
        public async Task<IActionResult> GetProductReceiptSearch([FromQuery] ProductReceiptParameters productReceiptvendorParameters)
        {
            var productReceiptSearch = await _repository.ProductReceipt.GetSearchProductReceiptAsync(productReceiptvendorParameters, trackChanges: false);
            var productReceiptsDto = _mapper.Map<IEnumerable<ProductReceiptDto>>(productReceiptSearch);
            return Ok(productReceiptsDto);
        }//endMethodSearch

    }
}
