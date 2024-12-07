using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KpayTransferSystemKZT.RestApi.Features.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly UserService _service;

        public DepositController()
        {
            _service = new UserService();
        }

        [HttpPost]
        public IActionResult Deposit([FromBody] UserDepositModel requestModel)
        {
            var model = _service.Deposit(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }
    }
}
