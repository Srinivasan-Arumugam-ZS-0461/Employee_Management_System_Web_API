using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLibrary.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly EmployeeDbContext _context;
        public CompanyRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            var companies = await _context.Companies.ToListAsync();
            return companies;
        }

        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            var company = await _context.Companies.FindAsync(id);
            return company;
        }

        public async Task<Company> AddCompanyAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            var existingCompany = await GetCompanyByIdAsync(company.Id);
            existingCompany.Name = company.Name;
            existingCompany.Address = company.Address;
            existingCompany.Description = company.Description;
            existingCompany.PhoneNumber = company.PhoneNumber;
            existingCompany.Email = company.Email;
            existingCompany.UpdatedOn = DateTime.Now;
            _context.Companies.Update(existingCompany);
            await _context.SaveChangesAsync();
            return existingCompany;
        }

        public async Task<bool> DeleteCompanyAsync(Guid id)
        {
            var company = await GetCompanyByIdAsync(id);
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
