using MediatR;

namespace EmployeeLibrary.Commands
{
    public record DeleteCompanyCommand(Guid companyId) : IRequest<bool>;

}
