using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Purchasing.Contracts;
using Purchasing.Entities.DTO;
using System.Threading.Tasks;

namespace Purchasing.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PurchasingController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "ListCartItem")]
        public async Task<IActionResult> GetListCartItem(int id)
        {
            var listCartItem = await _repository.ListCartItem.GetListCartItemAsync(id, trackChanges: false);
            if (listCartItem == null)
            {
                _logger.LogInfo($"ListCartItem with Id : {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var listCartItemDto = _mapper.Map<ListCartItemDto>(listCartItem);
                return Ok(listCartItemDto);
            }
        }//endMethod GetListCartItem parameter id

    }
}
