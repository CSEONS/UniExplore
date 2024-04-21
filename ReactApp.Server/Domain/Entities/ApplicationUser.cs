using Microsoft.AspNetCore.Identity;

namespace AspXReactApp.Server.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public long? TelegramId { get; set; }
        public Permission Permission { get; set; }
        public string? TelegramState { get; set; } = string.Empty;
        public string? TelegramStateDetails { get; set; } = string.Empty;
        public string? TelegramStateData {  get; set; } = string.Empty;
    }

    public enum Permission
    { 
        Admin,
        Moderator,
        Teacher,
        Student,
    }

}
