public class CourseService : ICourseService
{
    private readonly ApplicationDbContext _context;
    private readonly IAuditLogService _auditLogService;

    public CourseService(ApplicationDbContext context, IAuditLogService auditLogService)
    {
        _context = context;
        _auditLogService = auditLogService;
    }

    // ... existing methods ...

    public async Task<Course> GetCourseByIdAsync(int courseId, string userId)
    {
        var course = await _context.Courses
            .Include(c => c.Subjects)
                .ThenInclude(s => s.Exercises)
            .FirstOrDefaultAsync(c => c.Id == courseId);

        if (course == null)
        {
            throw new NotFoundException($"Course with ID {courseId} not found.");
        }

        // Log the access
        await _auditLogService.LogAsync(new AuditLog
        {
            UserId = userId,
            Action = "GetCourseById",
            EntityType = "Course",
            EntityId = courseId.ToString(),
            Timestamp = DateTime.UtcNow
        });

        return course;
    }
}
