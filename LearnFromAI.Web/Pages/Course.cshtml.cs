using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LearnFromAI.Web.Services;
using System.Threading.Tasks;

namespace LearnFromAI.Web.Pages
{
  public class CourseModel : PageModel
  {
    private readonly ICourseService _courseService;

    public CourseModel(ICourseService courseService)
    {
      _courseService = courseService;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
      var course = await _courseService.GetCourseByIdAsync(id);

      if (course == null)
      {
        return NotFound();
      }

      if (course.Subjects.Count > 0)
      {
        // Redirect to the first subject of the course
        return RedirectToPage("/Subject", new { id = course.Subjects[0].Id });
      }

      // If the course has no subjects, you might want to handle this case
      // For now, let's redirect to the home page
      return RedirectToPage("/Index");
    }
  }
}
