using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnFromAI.Data;
using LearnFromAI.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnFromAI.Web.Services
{
  public class CourseService : ICourseService
  {
    private readonly ApplicationDbContext _context;

    public CourseService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync(string? searchTerm = null)
    {
      IQueryable<Course> query = _context.Courses;

      if (!string.IsNullOrWhiteSpace(searchTerm))
      {
        searchTerm = searchTerm.ToLower();
        query = query.Where(c => c.Title.ToLower().Contains(searchTerm) ||
                                 c.Content.ToLower().Contains(searchTerm));
      }

      return await query.ToListAsync();
    }

    public async Task<Course> GetCourseByIdAsync(int courseId)
    {
      var course = await _context.Courses
          .Include(c => c.Subjects)
              .ThenInclude(s => s.Exercises)
          .FirstOrDefaultAsync(c => c.Id == courseId);

      if (course == null)
      {
        throw new Exception($"Course with ID {courseId} not found.");
      }

      return course;
    }

    public async Task<Subject> GetSubjectByIdAsync(int subjectId)
    {
      var subject = await _context.Subjects
          .Include(s => s.Exercises)
          .FirstOrDefaultAsync(s => s.Id == subjectId);

      if (subject == null)
      {
        throw new Exception($"Subject with ID {subjectId} not found.");
      }

      return subject;
    }

    public async Task<Exercise> GetExerciseWithSubjectAndCourseAsync(int exerciseId)
    {
      var exercise = await _context.Exercises
          .Include(e => e.Subject)
          .ThenInclude(s => s.Course)
          .FirstOrDefaultAsync(e => e.Id == exerciseId);

      if (exercise == null)
      {
        throw new Exception($"Exercise with ID {exerciseId} not found.");
      }

      return exercise;
    }
  }
}
