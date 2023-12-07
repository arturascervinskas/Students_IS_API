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
                int rowsAffected = _connection.Execute("INSERT INTO department (name) VALUES (@Name)", department);
                return rowsAffected == 1;
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
    }
}
