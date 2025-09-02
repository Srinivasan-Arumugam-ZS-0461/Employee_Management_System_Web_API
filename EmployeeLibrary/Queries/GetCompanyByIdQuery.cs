using MediatR;
using EmployeeLibrary.DTO;

namespace EmployeeLibrary.Queries
{
    public record GetCompanyByIdQuery(Guid Id) : IRequest<CompanyDTO>;

}
