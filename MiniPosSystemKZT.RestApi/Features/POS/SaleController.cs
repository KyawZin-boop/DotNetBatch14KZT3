using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiniPosSystemKZT.RestApi.Features.POS;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly SaleService _service;

    public SaleController()
    {
        _service = new SaleService();
    }

    [HttpGet]
    public IActionResult GetHistories()
    {
        var model = _service.GetHistories();
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetHistory(string id)
    {
        var model = _service.GetHistory(id);
        if (model is null)
        {
            return NotFound("No data found!");
        }

        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreateHistory([FromBody] SaleModel requestModel)
    {
        var model = _service.CreateHistory(requestModel);
        if (model is null)
        {
            return BadRequest(model);
        }
        return Ok(model);
    }

}
