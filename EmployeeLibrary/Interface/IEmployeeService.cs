using EmployeeLibrary.Enums;
using EmployeeLibrary.Models;

namespace EmployeeLibrary.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(Guid companyId);
        Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(EmployeeRoles role);

    }
}
