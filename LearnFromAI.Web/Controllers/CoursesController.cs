using Microsoft.AspNetCore.Mvc;
using LearnFromAI.Web.Services;
using LearnFromAI.Web.Models;

namespace LearnFromAI.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CoursesController : ControllerBase
  {
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
      _courseService = courseService;
    }

    /// <summary>
    /// Get a course by its ID
    /// </summary>
    /// <param name="id">The ID of the course</param>
    /// <returns>The course details</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCourseAsync(int id)
    {
      var course = await _courseService.GetCourseByIdAsync(id);
      if (course == null)
      {
        return NotFound();
      }
      return Ok(course);
    }
  }
}
