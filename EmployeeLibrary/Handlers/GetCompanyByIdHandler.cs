using AutoMapper;
using EmployeeLibrary.DTO;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Queries;
using MediatR;

namespace EmployeeLibrary.Handlers
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDTO>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public GetCompanyByIdHandler(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<CompanyDTO> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyService.GetCompanyByIdAsync(request.Id);
            return _mapper.Map<CompanyDTO>(company);
        }
    }
}
