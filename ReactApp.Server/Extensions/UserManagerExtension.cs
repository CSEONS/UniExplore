using AspXReactApp.Server.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspXReactApp.Server.Extensions
{
    public static class UserManagerExtension
    {
        public static ApplicationUser? FindByTelegramId(this UserManager<ApplicationUser> userManager, long telegramId)
        {
            var user = userManager.Users.FirstOrDefault(u => u.TelegramId == telegramId);

            return user;
        }
    }
}
