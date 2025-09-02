using AutoMapper;
using EmployeeLibrary.DTO;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using EmployeeLibrary.Queries;
using MediatR;

namespace EmployeeLibrary.Handlers
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyDTO>>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public GetAllCompaniesHandler(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDTO>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Company> companies = await _companyService.GetAllCompaniesAsync();
            IEnumerable<CompanyDTO> companiesDTO = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
            return companiesDTO;
        }
    }
}
