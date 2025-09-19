using EmployeeLibrary.DTO;
using MediatR;

namespace EmployeeLibrary.Queries
{
    public record GetCompanyByIdQuery(Guid Id) : IRequest<CompanyDTO>;

}
