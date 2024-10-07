using System.Collections.Generic;
using System.Threading.Tasks;
using LearnFromAI.Web.Models;

namespace LearnFromAI.Web.Services
{
  public interface ICourseService
  {
    Task<IEnumerable<Course>> GetAllCoursesAsync(string? searchTerm = null);

    Task<Course> GetCourseByIdAsync(int id);

    Task<Subject> GetSubjectByIdAsync(int id);

    Task<Exercise> GetExerciseWithSubjectAndCourseAsync(int exerciseId);
  }
}
