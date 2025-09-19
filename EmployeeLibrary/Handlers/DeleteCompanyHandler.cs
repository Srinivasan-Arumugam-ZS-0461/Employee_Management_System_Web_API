using AutoMapper;
using EmployeeLibrary.Commands;
using EmployeeLibrary.Interface;
using MediatR;

namespace EmployeeLibrary.Handlers
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, bool>
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public DeleteCompanyHandler(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            return await _companyService.DeleteCompanyAsync(request.companyId);
        }

    }
}
