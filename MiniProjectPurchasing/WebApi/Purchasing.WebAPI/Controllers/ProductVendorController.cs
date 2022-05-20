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
    public class ProductVendorController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductVendorController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductVendor()
        {
            try
            {
                var productvendors = await _repository.ProductVendor.GetAllProductVendorAsync(trackChanges: false);

                var productvendorsDto = _mapper.Map<IEnumerable<vPurchaseOrderVendorDto>>(productvendors);

                return Ok(productvendorsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetProductVendor)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }//EndMethodGetVendor

    }//endClassVendor
}
