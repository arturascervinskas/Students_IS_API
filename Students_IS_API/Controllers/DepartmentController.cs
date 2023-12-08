using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students_IS_API.Dtos;
using Students_IS_API.Interfaces;
using Students_IS_API.Models;
using Students_IS_API.Services;

namespace Students_IS_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentService department, ILogger<DepartmentController> logger)
        {

            _departmentService = department;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {

            _logger.LogInformation("Seri Log is Working");

            return Ok(_departmentService.GetDepartment());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {

            return Ok(_departmentService.AddDepartment(department));
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseRequestDto request)
        {

            return Ok(_departmentService.AddCourse(request));
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentRequestDto requestParams)
        {
            return Ok(_departmentService.AddStudent(requestParams));
        }

    }
}
