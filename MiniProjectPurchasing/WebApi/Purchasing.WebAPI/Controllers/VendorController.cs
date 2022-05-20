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
    public class VendorController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public VendorController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
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
        public async Task<IActionResult> GetVendorr(int id)
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
        public async Task<IActionResult> PostVendor([FromBody] VendorDto vendorDto)
        {
            if (vendorDto == null)
            {
                _logger.LogError("Vendor is null");
                return BadRequest("Vendor is null");
            }

            //object model state digunakan untuk validasi data yang ditangkap customerDto
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid modelstate vendorDto");
                return UnprocessableEntity(ModelState);
            }
            var vendorEntity = _mapper.Map<Vendor>(vendorDto);
            _repository.Vendor.CreateVendorAsync(vendorEntity);
            await _repository.SaveAsync();

            var vendorResult = _mapper.Map<VendorDto>(vendorEntity);
            return CreatedAtRoute("CustomerById", new { id = vendorResult.BusinessEntityID }, vendorResult);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var vendor = await _repository.Vendor.GetVendorAsync(id, trackChanges: false);
            if (vendor == null)
            {
                _logger.LogInfo($"Vendor with id : {id} doesn't exist in database");
                return NotFound();
            }

            _repository.Vendor.DeleteVendorAsync(vendor);
            await _repository.SaveAsync();
            return NoContent();
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
