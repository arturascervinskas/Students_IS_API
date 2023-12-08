using Students_IS_API.Dtos;
using Students_IS_API.Models;

namespace Students_IS_API.Interfaces
{
    public interface ICoursesRepository
    {
        public bool Addcourse(Courses course);
        public bool AddCourseToDepartment(AddCourseRequestDto request);
        public IEnumerable<Courses> GetCourses();
    }
}
