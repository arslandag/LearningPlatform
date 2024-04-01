using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Api.Contracts.Users
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
 
}
