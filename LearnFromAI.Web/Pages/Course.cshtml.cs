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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            var firstSubject = course.Subjects.OrderBy(s => s.Order).FirstOrDefault();

            if (firstSubject == null)
            {
                return NotFound("This course has no subjects.");
            }

            return RedirectToPage("/Subject", new { id = firstSubject.Id });
        }
    }
}
