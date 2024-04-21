using AspXReactApp.Server.Infrastructure.Auth;

namespace AspXReactApp.Server.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string passwor, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(passwor, hashedPassword);
    }
}
