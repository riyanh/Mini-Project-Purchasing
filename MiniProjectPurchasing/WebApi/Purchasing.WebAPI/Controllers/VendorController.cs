using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchasing.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purchasing.Entities.DTO;
using System;
using Purchasing.Entities.RequesFeatures;

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
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetVendor)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }//EndMethodGetVendor

        [HttpGet("pagination")]
        public async Task<IActionResult> GetVendorPagination([FromQuery] VendorParameters vendorParameters)
        {
            var vendorPage = await _repository.Vendor.GetPaginationVendorAsync(vendorParameters, trackChanges: false);
            var vendorDto = _mapper.Map<IEnumerable<VendorDto>>(vendorPage);
            return Ok(vendorDto);
        }//endMethodPagination

        [HttpGet("search")]
        public async Task<IActionResult> GetVendorSearch([FromQuery] VendorParameters vendorParameters)
        {
            var vendorSearch = await _repository.Vendor.GetSearchVendorAsync(vendorParameters, trackChanges: false);
            var vendorDto = _mapper.Map<IEnumerable<VendorDto>>(vendorSearch);
            return Ok(vendorDto);
        }//endMethodSearch

    }//endClassVendor
}
