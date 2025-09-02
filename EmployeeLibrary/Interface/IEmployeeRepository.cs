using EmployeeLibrary.Enums;
using EmployeeLibrary.Models;

namespace EmployeeLibrary.Interface
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByIdAsync(Guid id);
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<Employee> UpdateEmployeeAsync(Employee employee);
        public Task<bool> DeleteEmployeeAsync(Guid id);
        public Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(Guid companyId);
        public Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(EmployeeRoles role);
    }
}
