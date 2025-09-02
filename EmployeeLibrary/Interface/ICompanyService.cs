using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLibrary.Models;

namespace EmployeeLibrary.Interface
{
    public interface ICompanyService
    {
        public Task<IEnumerable<Company>> GetAllCompaniesAsync();
        public Task<Company> GetCompanyByIdAsync(Guid id);
        public Task<Company> AddCompanyAsync(Company company);
        public Task<Company> UpdateCompanyAsync(Company company);
        public Task<bool> DeleteCompanyAsync(Guid id);
    }
}
