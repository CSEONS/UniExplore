using AspXReactApp.Server.MediatR.Auth;
using AspXReactApp.Server.MediatR.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/Account")]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
