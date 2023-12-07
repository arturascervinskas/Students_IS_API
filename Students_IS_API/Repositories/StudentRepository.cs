using Dapper;
using Students_IS_API.Dtos;
using Students_IS_API.Interfaces;
using Students_IS_API.Models;
using System.Data;
using System.Data.Common;

namespace Students_IS_API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _connection;

        public StudentRepository(IDbConnection connection)

        {
            _connection = connection;

        }

        public bool AddDepartment(AddDepartmentRequestDot requestParams)
        {
            try
            {
                var obj = new
                {
                    Department_Id = requestParams.departmentId,
                    StudentId = requestParams.studentId
                };

                var rowsAffected = _connection.Execute("UPDATE students SET Department_id = @Department_Id WHERE id = @StudentId;", obj);

                return rowsAffected == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#AddShopItem ", ex);
            }
        }

        public bool AddStudents(StudentDto student)
        {
            try
            {
                int rowsAffected = _connection.Execute("INSERT INTO students (Department_id,Name, Surname) VALUES ( @Department_Id, @Name, @Surname)", student);
                return rowsAffected == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#AddShopItem ", ex);
            }
        }

        public IEnumerable<Student> GetStudentByID(int id)
        {
            try
            {
                return _connection.Query<Student>("SELECT * FROM students WHERE students.id = @id", new { id });
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#GetStudentByID", ex);
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            try
            {
                return _connection.Query<Student>("Select * FROM students");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#GetStudents", ex);
            }
        }
    }
}
