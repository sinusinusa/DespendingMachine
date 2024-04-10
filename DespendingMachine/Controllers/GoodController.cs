using Despending.Logic.Abstractions;
using DespendingMachine.Contracts;
using GoodsLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace DespendingMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodController : ControllerBase
    {
        private readonly IDespendingService _despendingService;
        public GoodController(IDespendingService despendingService)
        {
            _despendingService = despendingService;
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateGood([FromBody] GoodRequest request)
        {
            var (good, error) = Good.Create(
                Guid.NewGuid(), request.title, request.price, request.count, request.image
                );
            if(string.IsNullOrEmpty(error))
            {
                var id = await _despendingService.CreateGood(good);
                return Ok(id);
            }
            else
            {
                return BadRequest(error);
            }
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateGood(Guid id, [FromBody] GoodUpdate request)
        {
            var goodId = await _despendingService.UpdateGood(id, request.title, request.price, request.count, request.image);
            if (goodId != Guid.Empty)
            {
                return Ok(goodId);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteGood(Guid id)
        {
            var goodId = await _despendingService.DeleteGood(id);
            if (goodId != Guid.Empty)
            {
                return Ok(goodId);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
