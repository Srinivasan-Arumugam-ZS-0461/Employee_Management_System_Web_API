using EmployeeLibrary.Exceptions;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeLibrary.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompanyService> _logger;
        public CompanyService(ICompanyRepository companyRepository, ILogger<CompanyService> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all the Companies");
                IEnumerable<Company> companies = await _companyRepository.GetAllCompaniesAsync(); // how to handle null here
                if(!companies.Any())
                {
                    _logger.LogInformation("No Companies found!");
                }
                else
                {
                    _logger.LogInformation("Companies Found : {@companies}", companies);
                }
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
                _logger.LogInformation("Fetching Company with Id : {CompanyId}", id);
                Company company = await _companyRepository.GetCompanyByIdAsync(id);

                //if(company == null)
                //{
                //    _logger.LogWarning("Company with Id {CompanyId} not found!", id);
                //}
                //else
                //{
                //    _logger.LogInformation("Successfully fetched the company with Id {CompanyId}", id);
                //}
                return company; 
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
                _logger.LogInformation("Adding a new Company with the Name : {CompanyName}", company.Name);
                
                if (string.IsNullOrWhiteSpace(company.Name))
                {
                    _logger.LogWarning("Attempted to add a Company with an empty name.");
                    throw new ArgumentNullException("Company name cannot be empty."); // to be caught and handled in the controller
                }
                company.IsActive = true;
                company.CreatedOn = DateTime.Now;
                company.UpdatedOn = DateTime.Now;
                _logger.LogInformation("Successfully added a new Company : {CompanyName}", company.Name);
                return await _companyRepository.AddCompanyAsync(company);
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
                _logger.LogInformation("Updating Company with Id {CompanyId}", company.Id);

                var result = await _companyRepository.UpdateCompanyAsync(company);

                _logger.LogInformation("Company with Id {CompanyId} updated successfully!", result.Id);

                return result;
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
                _logger.LogInformation("Deleting Company with Id {CompanyId}", id);
                
                var isDeleted = await _companyRepository.DeleteCompanyAsync(id);

                if (isDeleted)
                {
                    _logger.LogInformation("Company with Id {CompanyId} deleted successfully!", id);
                }
                else
                {
                    _logger.LogInformation("Failed to delete Company with Id {CompanyId} - not found", id);
                }
                    return isDeleted;
            } 
            catch (Exception)
            {
                throw;
            }
        }
    }
}
