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
    [Route("api/purchasing/vendor")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IServiceVendor _serviceVendor;

        public VendorController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IServiceVendor serviceVendor)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _serviceVendor = serviceVendor;
        }

        [HttpGet]
        public async Task<IActionResult> GetVendor()
        {
            try
            {
                var vendors = await _repository.Vendor.GetAllVendoryAsync(trackChanges: false);

                var vendorsDto = _mapper.Map<IEnumerable<VendorDto>>(vendors);

                return Ok(vendorsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetVendor)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet("{id}", Name = "BusinessEntityd")]
        public async Task<IActionResult> GetVendor(int id)
        {
            var vendor = await _repository.Vendor.GetVendorAsync(id, false);
            if (vendor == null)
            {
                _logger.LogInfo($"Vendor with id: {id} not found");
                return NotFound();
            }
            else
            {
                var vendorDto = _mapper.Map<VendorDto>(vendor);
                return Ok(vendorDto);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostVendor([FromBody] ProductVendorDto productVendorDto)
        {
            if (productVendorDto == null)
            {
                _logger.LogError("Profile Data is null");
                return BadRequest("Profile Data is null");
            }
            //Object modelState digunakan untuk validasi data yang ditangkap oleh customerdto
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid modelstate Dto");
                return UnprocessableEntity(ModelState);
            }
            var postVendor = await _serviceVendor.NewVendor(productVendorDto);
            //await _repository.SaveAsync();
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendor(int id, [FromBody] VendorDto vendorDto)
        {
            if (vendorDto == null)
            {
                _logger.LogError("Vendor must not be null");
                return BadRequest("Vendor must not be null");
            }



            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for vendordto object");
                return UnprocessableEntity(ModelState);
            }
            var vendorEntity = await _repository.Vendor.GetVendorAsync(id, trackChanges: true);

            if (vendorEntity == null)
            {
                _logger.LogError($"Vendor with id : {id} not found");
                return NotFound();
            }

            _mapper.Map(vendorDto, vendorEntity);
            //_repository.Customer.UpdateCustomer(customerEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }//endClassVendor
}
