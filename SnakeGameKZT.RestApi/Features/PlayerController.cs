using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SnakeGameKZT.RestApi.Features;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _service;

    public PlayerController()
    {
        _service = new PlayerService();
    }

    [HttpGet]
    public IActionResult GetPlayers()
    {
        var model = _service.GetPlayers();
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetPlayer(int id)
    {
        var model = _service.GetPlayer(id);
        if (model is null) return NotFound("User not found!");
        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreatePlayer([FromBody] PlayerModel requestModel)
    {
        var model = _service.CreatePlayer(requestModel);
        if(model is null)
        {
            return BadRequest(model);
        }

        return Ok(model);
    }
}
