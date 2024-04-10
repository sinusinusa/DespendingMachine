using Despending.Logic.Abstractions;
using Despending.Logic.Models;
using DespendingMachine.Contracts;
using GoodsLibrary.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DespendingMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDespendingService _despendingService;
        private readonly ISecret _secret; 
        public UserController(IDespendingService despendingService, ISecret secret)
        {
            _despendingService = despendingService;
            _secret = secret;
        }
        [HttpGet("admin/{secret:alpha}")]
        public async Task<ActionResult> Admin(string secret)
        {
            var access = await _secret.Check(secret);
            if (access) return Redirect("https://localhost:7246/SuperSecretAdminPanel2000");
            else return BadRequest("Access denied");
        }
        [HttpGet("getCoins")]
        public async Task<ActionResult<List<GoodResponse>>> GetCoins()
        {
            var goods = await _despendingService.GetAllCoins();

            var response = goods.ToArray();

            return Ok(response);
        }

        [HttpGet("getGoods")] 
        public async Task<ActionResult<List<GoodResponse>>> GetGoods()
        {
            var goods = await _despendingService.GetAllGoods();

            var response = goods.Select(x => new GoodResponse(x.Id, x.Title, x.Price, x.Count, x.Image));

            return Ok(response);
        }
        [HttpPost("despend/{id:guid}")]
        public async Task<ActionResult<bool>> Despend(Guid id, [FromBody] List<PickCoin> pickCoins)
        {
            var success = await _despendingService.Despend(pickCoins, id);
            if (success)
            {
                return Ok(success);
            }
            else
            {
                return Ok(success);
            }
        }
    }
}
