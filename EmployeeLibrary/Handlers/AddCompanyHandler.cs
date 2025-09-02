using AutoMapper;
using EmployeeLibrary.Commands;
using EmployeeLibrary.DTO;
using EmployeeLibrary.Interface;
using EmployeeLibrary.Models;
using MediatR;

namespace EmployeeLibrary.Handlers
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, CompanyDTO>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public AddCompanyHandler(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<CompanyDTO> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            Company newCompany = _mapper.Map<Company>(request.addCompanyDTO);
            Company addedcompany = await _companyService.AddCompanyAsync(newCompany);
            return _mapper.Map<CompanyDTO>(addedcompany);
        }
    }
}
