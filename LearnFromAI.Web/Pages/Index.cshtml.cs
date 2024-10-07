using LearnFromAI.Web.Models;
using LearnFromAI.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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
            Courses = await _courseService.GetAllCoursesAsync();
        }
    }
}
