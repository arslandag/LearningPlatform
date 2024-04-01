using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Api.Contracts.Course
{
    public record GetCourseResponse(
        Guid Id,
        string Title,
        string Description,
        decimal Price
        );
}
