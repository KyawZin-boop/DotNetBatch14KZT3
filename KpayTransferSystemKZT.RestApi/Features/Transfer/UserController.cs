using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KpayTransferSystemKZT.RestApi.Features.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var model = _userService.GetUsers();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(string id)
        {
            var model = _userService.GetUser(id);
            if (model is null)
            {
                return NotFound("No data found!");
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel requestUser)
        {
            var model = _userService.CreateUser(requestUser);
            if (model is null)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpsertUser(string id, UserModel requestUser)
        {
            requestUser.UserId = id;
            var model = _userService.UpsertUser(requestUser);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateUser(string id, UserModel requestUser)
        {
            requestUser.UserId = id;
            var model = _userService.UpdateUser(requestUser);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var model = _userService.DeleteUser(id);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok(model);
        }

    }
}
