using EmployeeLibrary.Exceptions;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;

namespace EmployeeLibrary.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            try
            {
                IEnumerable<Company> companies = await _companyRepository.GetAllCompaniesAsync(); // how to handle null here
                return companies;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            try
            {
                return await _companyRepository.GetCompanyByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Company> AddCompanyAsync(Company company)
        {
            try
            {
                company.IsActive = true;
                company.CreatedOn = DateTime.Now;
                company.UpdatedOn = DateTime.Now;
                return await _companyRepository.AddCompanyAsync(company);
            }
            catch (CompanyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Company> UpdateCompanyAsync(Company company)
        {
            try
            {
                return await _companyRepository.UpdateCompanyAsync(company);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteCompanyAsync(Guid id)
        {
            try
            {
                return await _companyRepository.DeleteCompanyAsync(id);
            } 
            catch (Exception)
            {
                throw;
            }
        }
    }
}
