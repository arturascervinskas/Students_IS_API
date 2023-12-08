using Microsoft.AspNetCore.Mvc;
using Students_IS_API.Dtos;
using Students_IS_API.Interfaces;
using Students_IS_API.Models;

namespace Students_IS_API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool AddDepartment(AddDepartmentRequestDto requestParams)

        {
            try
            {
                IEnumerable<Student> data = _studentRepository.GetStudentByID(requestParams.studentId);

                if (data != null && data.All(s => s.Department_Id != null))
                {
                    throw new ApplicationException("Student already assigned to department");
                }

                return _studentRepository.AddDepartment(requestParams);

            }
            catch (Exception ex)
            {

                throw new ApplicationException("#GetStudentByID", ex);
            }

        }

        public bool AddStudents(StudentDto student)
        {
            return _studentRepository.AddStudents(student);
        }

        public IEnumerable<Student> GetDepartmentStudents(int id)
        {
            return _studentRepository.GetDepartmentStudents(id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

    }


}
