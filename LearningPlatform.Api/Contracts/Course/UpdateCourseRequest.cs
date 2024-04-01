using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Api.Contracts.Course
{
    public record UpdateCourseRequest(
        [Required] string Title,
        [Required] string Description,
        [Required] decimal Price
        );
}
