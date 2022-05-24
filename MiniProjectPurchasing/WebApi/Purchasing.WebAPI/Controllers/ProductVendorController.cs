using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchasing.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purchasing.Entities.DTO;
using Purchasing.Entities.Models;
using System;

namespace Purchasing.WebAPI.Controllers
{
    [Route("api/purchasing")]
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

        [HttpPost]
        public async Task<IActionResult> PostNewProductVendor([FromBody] ProductVendorDto productVendor)
        {
            if (productVendor == null)
            {
                _logger.LogError("Product is null");
                return BadRequest("Product is null");
            }
            //Object modelState digunakan untuk validasi data yang ditangkap oleh customerdto
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid modelstate");
                return UnprocessableEntity(ModelState);
            }

            var productVendorHEntity = _mapper.Map<ProductVendor>(productVendor);
            _repository.ProductVendorH.CreateProductVendorHAsync(productVendorHEntity);
            var productVendorResult = _mapper.Map<ProductVendor>(productVendorHEntity);
            return CreatedAtRoute("ProductVendorById", new { id = productVendorResult.BusinessEntityID },productVendorResult);
        }
    }//endClassVendor
}
