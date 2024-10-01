using System.Collections.Generic;
using System.Threading.Tasks;
using LearnFromAI.Models;

namespace LearnFromAI.Services
{
  public interface ICourseService
  {
    Task<IEnumerable<Course>> GetCoursesAsync(string? searchTerm = null);

    Task<Course> GetCourseByIdAsync(int id);

    Task<Subject> GetSubjectByIdAsync(int id);

    Task<Exercise> GetExerciseWithSubjectAndCourseAsync(int exerciseId);
  }
}
