using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SnakeGameKZT.RestApi.Features.GameMoves
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameMovesController : ControllerBase
    {
        private readonly GameMovesService _service;

        public GameMovesController()
        {
            _service = new GameMovesService();
        }

        [HttpPost]
        public IActionResult CreateMove([FromBody] GameMovesRequestModel requestModel)
        {
            var model = _service.CreateMove(requestModel);
            return Ok(model);
        }
    }
}
