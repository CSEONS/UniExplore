using AspXReactApp.Server.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspXReactApp.Server.Service
{
    public class DataManager
    {
        public UserManager<ApplicationUser> UserManager { get; set; }
        public RoleManager<IdentityRole<Guid>> RoleManager { get; set; }

        public DataManager(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
    }
}
