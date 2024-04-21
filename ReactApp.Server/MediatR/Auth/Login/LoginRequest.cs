using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Auth.Login
{
    public class LoginRequest : IRequest<IActionResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
