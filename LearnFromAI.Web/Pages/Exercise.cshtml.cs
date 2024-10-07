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
            Console.WriteLine($"Fetching exercise with id: {id}");

            var exerciseWithDetails = await _courseService.GetExerciseWithSubjectAndCourseAsync(id);

            if (exerciseWithDetails == null || exerciseWithDetails.Subject == null || exerciseWithDetails.Subject.Course == null)
            {
                Console.WriteLine($"Exercise with id {id} not found or has incomplete data");
                return NotFound();
            }

            Exercise = exerciseWithDetails;
            Subject = Exercise.Subject;
            Course = Subject.Course;

            Console.WriteLine($"Exercise found: {Exercise.Headline}");

            return Page();
        }
    }
}
