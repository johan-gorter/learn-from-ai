using System.Threading.Tasks;
using LearnFromAI.Web.Models;
using LearnFromAI.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnFromAI.Web.Pages
{
    public class CourseModel : PageModel
    {
        private readonly ICourseService _courseService;

        public CourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public Course Course { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Course = await _courseService.GetCourseByIdAsync(id);

            if (Course == null)
            {
                ErrorMessage = "Course not found.";
                return Page();
            }

            if (Course.Subjects == null || Course.Subjects.Count == 0)
            {
                ErrorMessage = "This course has no subjects.";
                return Page();
            }

            // Redirect to the first subject of the course
            return RedirectToPage("/Subject", new { id = Course.Subjects[0].Id });
        }
    }
}
