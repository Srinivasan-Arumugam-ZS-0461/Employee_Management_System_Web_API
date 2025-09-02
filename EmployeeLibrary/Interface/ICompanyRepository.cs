using EmployeeLibrary.Models;

namespace EmployeeLibrary.Interface
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(Guid id);
        Task<Company> AddCompanyAsync(Company company);
        Task<Company> UpdateCompanyAsync(Company company);
        Task<bool> DeleteCompanyAsync(Guid id);
        //GetCompanyByEmployeeId - TBD
    }
}
