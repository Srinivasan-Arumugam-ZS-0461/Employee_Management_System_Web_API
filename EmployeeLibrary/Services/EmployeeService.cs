using EmployeeLibrary.Enums;
using EmployeeLibrary.Exceptions;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;

namespace EmployeeLibrary.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                return await _employeeRepository.GetAllEmployeesAsync();
            }
            catch (EmployeeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            try
            {
                return await _employeeRepository.GetEmployeeByIdAsync(id);
            }
            catch (EmployeeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Task<Employee> AddEmployeeAsync(Employee employee)
        {
            try
            {
                return _employeeRepository.AddEmployeeAsync(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                return await _employeeRepository.UpdateEmployeeAsync(employee);
            }
            catch (EmployeeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            try
            {
                return await _employeeRepository.DeleteEmployeeAsync(id);
            }
            catch (EmployeeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(Guid companyId)
        {
            try
            {
                return await _employeeRepository.GetEmployeesByCompanyIdAsync(companyId);
            }
            catch (EmployeeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(EmployeeRoles role)
        {
            try
            {
                return await _employeeRepository.GetEmployeesByRoleAsync(role);
            }
            catch (EmployeeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
