using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SnakeGameKZT.RestApi.Features.GameBoard;

[Route("api/[controller]")]
[ApiController]
public class GameBoardController : ControllerBase
{
    private readonly GameBoardService _service;

    public GameBoardController()
    {
        _service = new GameBoardService();
    }

    [HttpPost]
    public IActionResult CreateBoard()
    {
        var model = _service.CreateBoard();
        return Ok(model);
    }
}
