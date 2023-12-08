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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {

            return Ok(_studentService.GetStudents());
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDto student)
        {
            return Ok(_studentService.AddStudents(student));

        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentRequestDto requestParams)
        {
            return Ok(_studentService.AddDepartment(requestParams));
        }


        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] AddDepartmentRequestDto requestParams)
        {
            return Ok(_studentService.AddDepartment(requestParams));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentStudents(int id)
        {
            return Ok(_studentService.GetDepartmentStudents(id));
        }
    }
}
