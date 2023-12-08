using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students_IS_API.Interfaces;
using Students_IS_API.Models;

namespace Students_IS_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;

        private readonly ILogger<DepartmentController> _logger;

        public CoursesController(ICoursesService courses, ILogger<DepartmentController> logger)
        {

            _coursesService = courses;
            _logger = logger;

            _logger.LogInformation("Seri Log is Working");

        }
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(_coursesService.GetCourses());
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Courses course)
        {

            return Ok(_coursesService.Addcourse(course));
        }
    }
}
