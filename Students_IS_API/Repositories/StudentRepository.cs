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

        public bool AddDepartment(AddDepartmentRequestDto requestParams)
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

        public bool AddStudents(StudentDto student)
        {
            try
            {
                return _connection.Execute("INSERT INTO students (Department_id,Name, Surname) VALUES ( @Department_Id, @Name, @Surname)", student) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#AddShopItem ", ex);
            }
        }

        public IEnumerable<Student> GetDepartmentStudents(int v, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetDepartmentStudents(int id)
        {
            var sql = @"SELECT students.name, students.surname, department.name AS DepartmentName
                FROM students
                JOIN Department ON Department.id = students.department_Id
                WHERE Department.id = @DepartmentId";

            var parameters = new { DepartmentId = id };

            return _connection.Query<Student, Department, Student>(
                sql,
                (student, department) =>
                {
                    student.Department = department;
                    return student;
                },
                splitOn: "DepartmentName", // Use the correct alias used in the SQL query
                param: parameters
            );
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
