using MediatR;

using Microsoft.AspNetCore.Mvc;

using Vocabularly.Features.Auth.Login;
using Vocabularly.Features.Auth.Register;

namespace Vocabularly.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { result.Token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.Success)
            {
                return Unauthorized(result.Errors);
            }

            return Ok(new { result.Token });
        }
    }
}
