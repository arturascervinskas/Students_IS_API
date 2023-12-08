using Students_IS_API.Models;

namespace Students_IS_API.Interfaces
{
    public interface ICoursesService
    {
        public bool Addcourse(Courses course);
        public IEnumerable<Courses> GetCourses();
    }
}
