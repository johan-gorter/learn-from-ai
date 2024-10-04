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
        public Subject Subject { get; set; }
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var exerciseWithDetails = await _courseService.GetExerciseWithSubjectAndCourseAsync(id);

            if (exerciseWithDetails == null)
            {
                return NotFound();
            }

            Exercise = exerciseWithDetails;
            Subject = Exercise.Subject;
            Course = Subject.Course;

            return Page();
        }
    }
}
