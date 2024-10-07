using System.Threading.Tasks;
using LearnFromAI.Web.Models;
using LearnFromAI.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Subject = await _courseService.GetSubjectByIdAsync(id);

            if (Subject == null)
            {
                ErrorMessage = "Subject not found.";
                return Page();
            }

            return Page();
        }
    }
}
