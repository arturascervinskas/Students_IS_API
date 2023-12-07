using Students_IS_API.Dtos;
using Students_IS_API.Interfaces;
using Students_IS_API.Models;

namespace Students_IS_API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repositoryDepartment;
        private readonly IStudentRepository _studentRepository;
        public DepartmentService(IDepartmentRepository repository, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _repositoryDepartment = repository;
        }
        public bool AddDepartment(Department department)
        {
            return _repositoryDepartment.AddDepartment(department);
        }

        //public bool AddStudentToDepartmen(DepartmentStudentDto data)
        //{
        //    try
        //    {
        //        //IEnumerable<Student> studenet = _studentRepository.GetStudentByID(data.StudentId);
        //        //foreach (Student student in studenet)
        //        //{
        //        //    if (student?.DepartmentId != null)
        //        //    {
        //        //        throw new InvalidOperationException("Student is already assigned to a department.");
        //        //    }

        //        //}
        //        return _studentRepository.SetDepartmentID(data);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("#AddStudentToDepartmen ", ex);

        //    }

        //}

        public IEnumerable<Department> GetDepartment()
        {
            return _repositoryDepartment.GetDepartment();

        }
    }
}
