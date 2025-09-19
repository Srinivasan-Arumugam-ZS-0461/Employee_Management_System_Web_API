using EmployeeLibrary.Enums;
using EmployeeLibrary.Exceptions;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeLibrary.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
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
                _logger.LogInformation("Adding a new employee: {EmployeeName}", employee.Name);

                if(string.IsNullOrWhiteSpace(employee.Name))
                {
                    _logger.LogWarning("Attempted to add an employee with an empty name.");
                    throw new EmployeeException("Employee name cannot be empty.");
                }
                _logger.LogInformation("Successfully added a new employee: {EmployeeName}", employee.Name);
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
