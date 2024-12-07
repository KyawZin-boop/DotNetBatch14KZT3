using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KpayTransferSystemKZT.RestApi.Features.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly UserService _service;

        public WithdrawController()
        {
            _service = new UserService();
        }

        [HttpPost]
        public IActionResult Withdraw(UserWithdrawModel requestModel)
        {
            var model = _service.Withdraw(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }
    }
}
