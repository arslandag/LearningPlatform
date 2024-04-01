namespace LearningPlatform.Api.Contracts.Lesson
{
    public record GetLessonsResponse(
        Guid Id,
        Guid CourseId,
        string Title,
        string Description,
        string VideoLink,
        string LessonText
        );
}
