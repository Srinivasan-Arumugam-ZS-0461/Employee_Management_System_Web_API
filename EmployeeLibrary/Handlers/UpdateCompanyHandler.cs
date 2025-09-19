using AutoMapper;
using EmployeeLibrary.Commands;
using EmployeeLibrary.DTO;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using MediatR;

namespace EmployeeLibrary.Handlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, CompanyDTO>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<CompanyDTO> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            Company updateCompany = _mapper.Map<Company>(request.updateCompanyDTO);
            Company updatedCompany = await _companyService.UpdateCompanyAsync(updateCompany);
            return _mapper.Map<CompanyDTO>(updatedCompany);
        }
    }
}
