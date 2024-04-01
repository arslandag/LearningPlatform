using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Api.Contracts.Users
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Password,
        [Required] string Email);
}
