using AspXReactApp.Server.Domain.Entities;
using AspXReactApp.Server.Service;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AspXReactApp.Server.MediatR.Auth.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, IActionResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginRequestHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return new NotFoundObjectResult(ActionInfo.UserNotFound.WithData(new { username = request.Username }));
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, request.Username) };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new OkObjectResult(new { token = token });
        }
    }
}
