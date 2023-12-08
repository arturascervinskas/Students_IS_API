using Students_IS_API.Dtos;
using Students_IS_API.Models;

namespace Students_IS_API.Interfaces
{
    public interface IDepartmentService
    {
        public bool AddCourse(AddCourseRequestDto request);
        public bool AddDepartment(Department department);
        public bool AddStudent(AddStudentRequestDto requestParams);
        public IEnumerable<Department> GetDepartment();
    }
}
