using EmployeeLibrary.DTO;
using EmployeeLibrary.Models;

namespace EmployeeLibrary.Mapper
{
    public class CompanyMapper
    {
        public static CompanyDTO MapToDTO(Company company)
        {
            return new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                CreatedOn = company.CreatedOn,
                UpdatedOn = company.UpdatedOn
                
            };
        }
        public static Company MapToEntity(CompanyDTO companyDTO)
        {
            return new Company
            {
                Name = companyDTO.Name,
                Description = companyDTO.Description,
                Address = companyDTO.Address,
                PhoneNumber = companyDTO.PhoneNumber,
                Email = companyDTO.Email
            };
        }
    }
}
