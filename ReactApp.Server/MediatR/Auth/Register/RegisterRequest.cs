using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Auth
{
    public class RegisterRequest : IRequest<IActionResult>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
