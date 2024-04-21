using AspXReactApp.Server.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspXReactApp.Server.Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminUser = new ApplicationUser()
            {
                Id = new Guid("e960bd79-cfc4-4422-be9f-350069f6e272"),
                UserName = "Admin",
                TelegramId = 1147571402
            };

            var adminRole = new IdentityRole<Guid>()
            {
                Id = new Guid("2e0a3996-a1db-43c1-b3e9-985bc97059e7"),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var adminUserRole = new IdentityUserRole<Guid>()
            {
                UserId = new Guid("e960bd79-cfc4-4422-be9f-350069f6e272"),
                RoleId = new Guid("2e0a3996-a1db-43c1-b3e9-985bc97059e7"),
            };

            builder.Entity<IdentityRole<Guid>>()
                .HasData(adminRole);

            builder.Entity<ApplicationUser>()
                .HasData(adminUser);

            builder.Entity<IdentityUserRole<Guid>>()
                .HasData(adminUserRole);
        }

    }
}
