using Dapper;
using Students_IS_API.Dtos;
using Students_IS_API.Interfaces;
using Students_IS_API.Models;
using System.Data;

namespace Students_IS_API.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly IDbConnection _connection;

        public CoursesRepository(IDbConnection connection)

        {
            _connection = connection;

        }
        public bool Addcourse(Courses course)
        {
            try
            {
                return _connection.Execute("INSERT INTO courses (name) VALUES (@name)", course) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#Addcourse", ex);
            }
        }

        public bool AddCourseToDepartment(AddCourseRequestDto request)
        {

            try
            {
                return _connection.Execute("INSERT INTO department_course (department_id, courses_id) VALUES (@departmentId, @coursesId)",
                    new { departmentId = request.DepartmentId, CoursesId = request.CourseId }) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("#Addcourse", ex);
            }
        }

        public IEnumerable<Courses> GetCourses()
        {
            try
            {
                return _connection.Query<Courses>("Select * From courses");

            }
            catch (Exception ex)
            {
                throw new ApplicationException("#Getcoure", ex);

            }
        }
    }
}
