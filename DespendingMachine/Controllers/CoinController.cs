using Despending.Logic.Abstractions;
using DespendingMachine.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DespendingMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinController : ControllerBase
    {
        private readonly IDespendingService _despendingService;
        public CoinController(IDespendingService despendingService)
        {
            _despendingService = despendingService;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateCoin(int id, bool? available, int? count)
        {
            var coinId = await _despendingService.UpdateCoin(id, available, count);
            if (coinId != 0)
            {
                return Ok(coinId);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
