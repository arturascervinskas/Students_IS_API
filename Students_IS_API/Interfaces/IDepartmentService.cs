using Students_IS_API.Dtos;
using Students_IS_API.Models;

namespace Students_IS_API.Interfaces
{
    public interface IDepartmentService
    {
        public bool AddDepartment(Department department);
        public IEnumerable<Department> GetDepartment();
    }
}
