﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnakeGameKZT.RestApi.Features.Player;

namespace SnakeGameKZT.RestApi.Features.Game
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _service;

        public GameController()
        {
            _service = new GameService();
        }

        [HttpPost]
        public IActionResult CreateGame([FromBody] GameRequestModel requestModel)
        {
            try
            {
                var model = _service.CreateGame(requestModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GameResponseModel
                {
                    Message = ex.Message,
                });
            }
        }
    }
}
