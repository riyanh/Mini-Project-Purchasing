using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchasing.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Purchasing.Entities.DTO;
using System;
using Purchasing.Entities.Models;

namespace Purchasing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipMethodController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ShipMethodController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetShipMethod()
        {
            try
            {
                var ships = await _repository.ShipMethod.GetAllShipMethodAsync(trackChanges: false);

                var shipMethodDto = _mapper.Map<IEnumerable<ShipMethodDto>>(ships);

                return Ok(shipMethodDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetShipMethod)} message : {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }//endClassVendor
}
