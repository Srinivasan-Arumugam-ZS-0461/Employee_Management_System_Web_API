using EmployeeLibrary.DTO;
using MediatR;

namespace EmployeeLibrary.Commands
{
    public record AddCompanyCommand(AddCompanyDTO addCompanyDTO) : IRequest<CompanyDTO>;
}
