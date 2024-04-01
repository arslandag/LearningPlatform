using LearningPlatform.Application.Interfaces.Auth;
using LearningPlatform.Application.Interfaces.Repositories;
using LearningPlatform.Core.Models;

namespace LearningPlatform.Application.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHashes;
        private readonly IJwtProvider _jwtProvider;
        private readonly IUsersRepository _usersRepository;

        public UserService(
            IUsersRepository usersRepository,
            IPasswordHasher passwordHashes,
            IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _passwordHashes = passwordHashes;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string userName, string email, string password)
        { 
            var hashedPassword = _passwordHashes.Generate(password);

            var user = User.Create(
                Guid.NewGuid(),
                userName,
                hashedPassword,
                email);

            await _usersRepository.Add(user);

        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _usersRepository.GetByEmail(email);

            var result = _passwordHashes.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Feild to login");
            }

            var token = _jwtProvider.Generate(user);

            return token;
        }
    }
}
