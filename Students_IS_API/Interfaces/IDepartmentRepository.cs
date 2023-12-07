using Students_IS_API.Models;

namespace Students_IS_API.Interfaces
{
    public interface IDepartmentRepository
    {
        bool AddDepartment(Department department);

        IEnumerable<Department> GetDepartment();
    }
}
