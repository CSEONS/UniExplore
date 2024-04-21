using AspXReactApp.Server.Domain.Entities;
using AspXReactApp.Server.Service;
using AspXReactApp.Server.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Auth
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, IActionResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterRequestHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user != null)
                return new BadRequestObjectResult(ActionInfo.EmailTaked.WithData(new { email = request.Email }));

            var newUser = new ApplicationUser { UserName = request.Email, Email = request.Email };

            var createUserResult = await _userManager.CreateAsync(newUser);

            if (createUserResult.Succeeded)
            {
                return new OkObjectResult(ActionInfo.UserCreated);
            }
            else
            {
                return new ObjectResult(new { id = -1, Message = createUserResult.Errors });
            }
        }

    }
}
