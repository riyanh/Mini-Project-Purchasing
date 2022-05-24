using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchasing.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purchasing.Entities.DTO;
using System;
using Purchasing.Entities.RequesFeatures;
using Purchasing.Entities.Models;

namespace Purchasing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProductController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                var products = await _repository.Product.GetAllProductAsync(trackChanges: false);

                var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetProduct)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        
    }//endClassVendor
}
