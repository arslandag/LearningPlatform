using LearningPlatform.Application.Interfaces.Auth;

namespace LearningPlatform.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) 
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string heshedPassword)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, heshedPassword);
    }
}
