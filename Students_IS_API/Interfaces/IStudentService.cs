using Microsoft.AspNetCore.Mvc;
using Students_IS_API.Dtos;
using Students_IS_API.Models;

namespace Students_IS_API.Interfaces
{
    public interface IStudentService
    {
        public bool AddDepartment(AddDepartmentRequestDot requestParams);
        public bool AddStudents(StudentDto student);
        public IEnumerable<Student> GetStudents();
    }
}
