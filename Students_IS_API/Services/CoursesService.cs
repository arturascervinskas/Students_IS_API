using Students_IS_API.Interfaces;
using Students_IS_API.Models;
using Students_IS_API.Repositories;

namespace Students_IS_API.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository _coursesRepository;
        public CoursesService(ICoursesRepository courses)
        {
        _coursesRepository = courses;
        }
        public bool Addcourse(Courses course)
        {
            return _coursesRepository.Addcourse(course);
        }

        public IEnumerable<Courses> GetCourses()
        {
           return _coursesRepository.GetCourses();
        }
    }
}
