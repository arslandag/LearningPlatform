using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Api.Contracts.Course
{
    public record CreateCourseRequest(
        [Required] string Title,
        [Required] string Description,
        [Required] decimal Price
        );
}
