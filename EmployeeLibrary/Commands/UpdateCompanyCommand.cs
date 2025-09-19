using EmployeeLibrary.DTO;
using MediatR;

namespace EmployeeLibrary.Commands
{
    public record UpdateCompanyCommand(UpdateCompanyDTO updateCompanyDTO) : IRequest<CompanyDTO>;
}
