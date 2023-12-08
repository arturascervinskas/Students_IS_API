using Students_IS_API.Dtos;
using Students_IS_API.Models;

namespace Students_IS_API.Interfaces
{
    public interface IDepartmentRepository
    {
        bool AddDepartment(Department department);
        bool AddStudent(AddStudentRequestDto requestParams);
        IEnumerable<Department> GetDepartment();
    }
}
