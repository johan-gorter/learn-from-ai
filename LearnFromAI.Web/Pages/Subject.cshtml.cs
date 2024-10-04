using LearnFromAI.Web.Models;
using LearnFromAI.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace LearnFromAI.Web.Pages
{
  public class SubjectModel : PageModel
  {
    private readonly ICourseService _courseService;

    public SubjectModel(ICourseService courseService)
    {
      _courseService = courseService;
    }

    public Subject Subject { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
      var subject = await _courseService.GetSubjectByIdAsync(id);
      if (subject == null)
      {
        return NotFound();
      }

      Subject = subject;

      return Page();
    }
  }
}
