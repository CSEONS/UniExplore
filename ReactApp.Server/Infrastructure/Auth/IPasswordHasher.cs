namespace AspXReactApp.Server.Infrastructure.Auth
{
    public interface IPasswordHasher
    {
        string Generate(string password);
        bool Verify(string passwor, string hashedPassword);
    }
}
