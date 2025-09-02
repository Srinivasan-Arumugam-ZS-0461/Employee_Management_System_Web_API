using EmployeeLibrary.Enums;
using EmployeeLibrary.Exceptions;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLibrary.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext _context)
        {
            this._context = _context;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            employee.CreatedOn = DateTime.Now;
            employee.UpdatedOn = DateTime.Now;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = await GetEmployeeByIdAsync(employee.Id);

            if (existingEmployee == null)
            {
                throw new EmployeeException($"Employee with ID {employee.Id} not found.");
            }

            employee.Id = existingEmployee.Id;
            existingEmployee.Name = employee.Name;
            existingEmployee.Address = employee.Address;
            existingEmployee.PhoneNumber = employee.PhoneNumber;
            existingEmployee.Email = employee.Email;
            existingEmployee.Role = employee.Role;
            existingEmployee.DOB = employee.DOB;
            existingEmployee.CompanyId = employee.CompanyId;
            existingEmployee.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();
            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(Guid companyId)
        {
            var employees = await _context.Employees.Where(e => e.CompanyId == companyId).ToListAsync();

            return employees;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByRoleAsync(EmployeeRoles role)
        {
            var employees = await _context.Employees.Where(e => e.Role == role).ToListAsync();
            return employees;
        }
    }
}