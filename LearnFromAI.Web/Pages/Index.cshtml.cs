using LearnFromAI.Data;
using LearnFromAI.Web.Models;
using LearnFromAI.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnFromAI.Web.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ICourseService _courseService;

    public IndexModel(ICourseService courseService)
    {
      _courseService = courseService;
    }

    public IEnumerable<Course> Courses { get; set; }

    public async Task OnGetAsync()
    {
      Courses = await _courseService.GetCoursesAsync();
    }

    public async Task<IActionResult> OnGetStartCourseAsync(int id)
    {
      var course = await _courseService.GetCourseByIdAsync(id);
      if (course == null || !course.Subjects.Any())
      {
        return NotFound();
      }

      var firstSubject = course.Subjects.OrderBy(s => s.Order).First();
      return RedirectToPage("/Subject", new { id = firstSubject.Id });
    }
  }
}
