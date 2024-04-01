using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.Api.Contracts.Lesson
{
    public record UpdateLessonRequest(
        [Required] string Title,
        [Required] string Description,
        [Required] string VideoLink,
        [Required] string LessonText);
}