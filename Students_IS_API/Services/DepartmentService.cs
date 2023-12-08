using Students_IS_API.Dtos;
using Students_IS_API.Interfaces;
using Students_IS_API.Models;
using Students_IS_API.Repositories;

namespace Students_IS_API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repositoryDepartment;
        private readonly IStudentRepository _studentRepository;
        private readonly ICoursesRepository _courseRepository;


        public DepartmentService(IDepartmentRepository repository, IStudentRepository studentRepository, ICoursesRepository coursesRepository)
        {
            _studentRepository = studentRepository;
            _repositoryDepartment = repository;
            _courseRepository = coursesRepository;
        }

        public bool AddCourse(AddCourseRequestDto request)
        {
           return _courseRepository.AddCourseToDepartment(request);
        }

        public bool AddDepartment(Department department)
        {
            return _repositoryDepartment.AddDepartment(department);
        }

        public bool AddStudent(AddStudentRequestDto requestParams)
        {
            try
            {
                IEnumerable<Student> data = _studentRepository.GetStudentByID(requestParams.studentId);

                if (data != null && data.All(s => s.Department_Id != null))
                {
                    throw new ApplicationException("Student already assigned to department");
                }

                return _repositoryDepartment.AddStudent(requestParams);

            }
            catch (Exception ex)
            {

                throw new ApplicationException("#GetStudentByID", ex);
            }
        }

        public IEnumerable<Department> GetDepartment()
        {
            return _repositoryDepartment.GetDepartment();

        }
    }
}
