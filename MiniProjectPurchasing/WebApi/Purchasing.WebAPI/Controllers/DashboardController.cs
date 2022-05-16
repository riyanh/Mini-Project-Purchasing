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
    public class DashboardController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DashboardController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Approved")]
        public async Task<IActionResult> GetApprovedVendor()
        {
            try
            {
                var approvedVendor = await _repository.ApprovedVendor.GetTotalApprovedAsync(trackChanges: false);

                var approvedVendorDto = _mapper.Map<IEnumerable<ApprovedVendorDto>>(approvedVendor);

                return Ok(approvedVendorDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetApprovedVendor)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }//EndMethodGet

        [HttpGet("search")]
        public async Task<IActionResult> GetStatusOrderSearch([FromQuery] StatusOrderParameters statusOrderParameters)
        {
            var statusOrderSearch = await _repository.StatusOrder.GetSearchStatusTotalVendorAsync(statusOrderParameters, trackChanges: false);
            var statusOrderDto = _mapper.Map<IEnumerable<StatusOrderDto>>(statusOrderSearch);
            return Ok(statusOrderDto);
        }//endMethodSearch

        [HttpGet("Month")]
        public async Task<IActionResult> GetTotalDueMonth()
        {
            try
            {
                var totalDueMonth = await _repository.TotalDueMonth.GetTotalDueMonthAsync(trackChanges: false);

                var totalDueMonthDto = _mapper.Map<IEnumerable<TotalDueMonthDto>>(totalDueMonth);

                return Ok(totalDueMonthDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetTotalDueMonth)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }//EndMethodGetStatusOrder

    }
}
