using Dapper;
using Students_IS_API.Dtos;
using Students_IS_API.Interfaces;
using Students_IS_API.Models;
using System.Data;

namespace Students_IS_API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DepartmentRepository(IDbConnection connection)

        {
            _connection = connection;

        }

        public bool AddDepartment(Department department)
        {
            try
            {
                return _connection.Execute("INSERT INTO department (name) VALUES (@Name)", department) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#AddShopItem ", ex);
            }
        }

        public bool AddStudent(AddStudentRequestDto requestParams)
        {
            try
            {
                var obj = new
                {
                    Department_Id = requestParams.departmentId,
                    StudentId = requestParams.studentId
                };

                return _connection.Execute("UPDATE students SET Department_id = @Department_Id WHERE id = @StudentId;", obj) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#AddShopItem ", ex);
            }
        }

        public IEnumerable<Department> GetDepartment()
        {
            try
            {
                return _connection.Query<Department>("Select * FROM department");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#GetDepartment ", ex);
            }
        }

        public IEnumerable<Student> GetDepartmentByID(int id)
        {
            try
            {
                return _connection.Query<Student>("SELECT * FROM depratment WHERE department.id = @id", new { id });
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#GetDepartmentByID", ex);
            }
        }
    }
}
