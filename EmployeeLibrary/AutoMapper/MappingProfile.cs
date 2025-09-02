using AutoMapper;
using EmployeeLibrary.DTO;
using EmployeeLibrary.Models;

namespace EmployeeLibrary.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Maps Company -> CompanyDTO
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Company, AddCompanyDTO>().ReverseMap();
            CreateMap<Company, UpdateCompanyDTO>().ReverseMap();
        }
    }
}
