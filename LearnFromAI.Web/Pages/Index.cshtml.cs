using Microsoft.AspNetCore.Mvc.RazorPages;
using LearnFromAI.Web.Services;

namespace LearnFromAI.Web.Pages
{
  public class IndexModel : PageModel
  {
    private readonly ICourseService _courseService;

    public IndexModel(ICourseService courseService)
    {
      _courseService = courseService;
    }

    public void OnGet()
    {
    }
  }
}
