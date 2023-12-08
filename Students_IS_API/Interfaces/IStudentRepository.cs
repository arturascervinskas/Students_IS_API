using Students_IS_API.Dtos;
using Students_IS_API.Models;

namespace Students_IS_API.Interfaces
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetStudentByID(int id);
        public bool AddStudents(StudentDto student);
        public IEnumerable<Student> GetStudents();
        bool AddDepartment(AddDepartmentRequestDto requestParams);
        IEnumerable<Student> GetDepartmentStudents(int v, int id);
        IEnumerable<Student> GetDepartmentStudents(int id);
    }
}
