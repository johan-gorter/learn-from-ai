public interface ICourseService
{
    // ... existing methods ...

    Task<Course> GetCourseByIdAsync(int courseId, string userId);
}
