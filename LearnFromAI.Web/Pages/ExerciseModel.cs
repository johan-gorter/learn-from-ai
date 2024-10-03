using System.Threading.Tasks;
using LearnFromAI.Web.Models;
using LearnFromAI.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnFromAI.Web.Pages
{
  public class ExerciseModel : PageModel
  {
    private readonly ICourseService _courseService;

    public ExerciseModel(ICourseService courseService)
    {
      _courseService = courseService;
    }

    public Exercise Exercise { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
      Exercise = await _courseService.GetExerciseWithSubjectAndCourseAsync(id);

      if (Exercise == null)
      {
        return NotFound();
      }

      return Page();
    }
  }
}
