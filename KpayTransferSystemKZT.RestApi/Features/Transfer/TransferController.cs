using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KpayTransferSystemKZT.RestApi.Features.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly TransferService _service;

        public TransferController()
        {
            _service = new TransferService();
        }

        [HttpGet]
        public IActionResult GetRecords()
        {
            var model = _service.GetRecords();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecord(string id)
        {
            var item = _service.GetRecord(id);
            if(item is null)
            {
                return NotFound("No data found!");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateTransfer(UserModel user, string fromMobile, string toMobile, string password, decimal amount, string notes)
        {
            var model = _service.CreateTransfer( user, fromMobile, toMobile, password, amount, notes);
            if (model is null)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }
    }

}
